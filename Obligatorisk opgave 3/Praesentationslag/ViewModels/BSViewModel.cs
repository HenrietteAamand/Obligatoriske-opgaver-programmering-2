using LiveCharts;
using LiveCharts.Wpf;
using Logic_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praesentationslag
{
    class BSViewModel
    {
        public SeriesCollection BS_Collection { get; set; }
        //private String explanation = "Systole er et udtryk for det laveste";
        //public String Explanation { get { return explanation; set{ Explanation } }

        private LineSeries line_bloodSugar = new LineSeries();

        public String[] dates { get; set; }
        public BSViewModel(MainWindow mainWindow, Logic logicRef)
        {
            createChart(mainWindow, logicRef);
            addBlodpreasure(mainWindow, logicRef);
        }
        private void createChart(MainWindow mainWindow, Logic logicRef)
        {
            line_bloodSugar = new LineSeries();
            BS_Collection = new SeriesCollection();

            dates = new String[logicRef.getBSugarData(mainWindow.SoSecNb).Count];

            //Opretter alle mine linjer med den korrekte værdi (her int)
            line_bloodSugar.Values = new ChartValues<double>();

            //Tilføje titler til min linje
            line_bloodSugar.Title = "Blodsukker";

            BS_Collection.Add(line_bloodSugar);
        }

        private void addBlodpreasure(MainWindow mainWindow, Logic logicRef)
        {
            for (int i = 0; i < logicRef.getBSugarData(mainWindow.SoSecNb).Count; i++)
            {
                line_bloodSugar.Values.Add(logicRef.getBSugarData(mainWindow.SoSecNb)[i].BloodSugar_);

                //Mine lables til x-axen
                dates[i] = logicRef.getBSugarData(mainWindow.SoSecNb)[i].Date_.ToString("dd/MM/yyyy hh:mm");
            }
        }
    }
}

