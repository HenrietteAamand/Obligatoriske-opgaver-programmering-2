using LiveCharts;
using LiveCharts.Wpf;
using Logic_Layer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer
{
    class BPViewModel
    {
        public SeriesCollection BP_Collection { get; set; }
        private LineSeries line_Systole, line_Diastole = new LineSeries();

        public String[] Dates { get; set; }
        public BPViewModel(MainWindow mainWindow, Logic logicRef)
        {
            CreateChart(mainWindow, logicRef);
            AddBlodpreasure(mainWindow, logicRef);
        }
        private void CreateChart(MainWindow mainWindow, Logic logicRef)
        {
            line_Diastole = new LineSeries { };
            line_Systole = new LineSeries();
            BP_Collection = new SeriesCollection();

            Dates = new String[logicRef.getBPressureData(mainWindow.SocSecNb).Count];

            //Opretter alle mine linjer med den korrekte værdi (her int)
            line_Diastole.Values = new ChartValues<int>();
            line_Systole.Values = new ChartValues<int>();

            //Tilføje titler til mine linjer
            line_Diastole.Title = "Diastolisk blodttryk";
            line_Systole.Title = "Systolisk blodtryk";

            BP_Collection.Add(line_Systole);
            BP_Collection.Add(line_Diastole);
        }

        private void AddBlodpreasure(MainWindow mainWindow, Logic logicRef)
        {
            for (int i = 0; i < logicRef.getBPressureData(mainWindow.SocSecNb).Count; i++)
            {
                line_Diastole.Values.Add(logicRef.getBPressureData(mainWindow.SocSecNb)[i].Diastolic_);
                line_Systole.Values.Add(logicRef.getBPressureData(mainWindow.SocSecNb)[i].Systolic_);

                //Mine lables til x-axen
                Dates[i] = logicRef.getBPressureData(mainWindow.SocSecNb)[i].Date_.ToString("dd/MM/yyyy hh:mm");
            }
        }
    }
}
