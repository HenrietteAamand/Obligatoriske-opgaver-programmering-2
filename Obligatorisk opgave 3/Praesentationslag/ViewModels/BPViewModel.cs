using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic_Layer;
using System.Windows.Input;


namespace Praesentationslag
{
    class BPViewModel
    {
        public SeriesCollection BP_Collection { get; set; }
        //private String explanation = "Systole er et udtryk for det laveste";
        //public String Explanation { get { return explanation; set{ Explanation } }

        private LineSeries line_Systole, line_Diastole = new LineSeries();

        public String[] dates { get; set; }
        public BPViewModel(MainWindow mainWindow, Logic logicRef)
        {
            createChart(mainWindow, logicRef);
            addBlodpreasure(mainWindow, logicRef);
        }
        private void createChart(MainWindow mainWindow, Logic logicRef)
        {
            line_Diastole = new LineSeries { };
            line_Systole = new LineSeries();
            BP_Collection = new SeriesCollection();

            dates = new String[logicRef.getBPressureData(mainWindow.SoSecNb).Count];

            //Opretter alle mine linjer med den korrekte værdi (her int)
            line_Diastole.Values = new ChartValues<int>();
            line_Systole.Values = new ChartValues<int>();

            //Tilføje titler til mine linjer
            line_Diastole.Title = "Diastolisk blodttryk";
            line_Systole.Title = "Systolisk blodtryk";

            BP_Collection.Add(line_Systole);
            BP_Collection.Add(line_Diastole);
        }

        private void addBlodpreasure(MainWindow mainWindow, Logic logicRef)
        {
            for (int i = 0; i < logicRef.getBPressureData(mainWindow.SoSecNb).Count; i++)
            {
                line_Diastole.Values.Add(logicRef.getBPressureData(mainWindow.SoSecNb)[i].Diastolic_);
                line_Systole.Values.Add(logicRef.getBPressureData(mainWindow.SoSecNb)[i].Systolic_);

                //Mine lables til x-axen
                dates[i] = logicRef.getBPressureData(mainWindow.SoSecNb)[i].Date_.ToString("dd/MM/yyyy hh:mm");
            }
        }
    }
}
