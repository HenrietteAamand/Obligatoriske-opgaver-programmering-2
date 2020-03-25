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
    class WeightViewModel
    {
        public SeriesCollection BMI_Collection { get; set; }
        public SeriesCollection Weight_Collection { get; set; }
        //private String explanation = "Systole er et udtryk for det laveste";
        //public String Explanation { get { return explanation; set{ Explanation } }

        private LineSeries line_BMI, line_Weight = new LineSeries();

        public String[] dates { get; set; }
        public WeightViewModel(MainWindow mainWindow, Logic logicRef)
        {
            createChart(mainWindow, logicRef);
            addBlodpreasure(mainWindow, logicRef);
        }
        private void createChart(MainWindow mainWindow, Logic logicRef)
        {
            line_BMI = new LineSeries { };
            line_Weight = new LineSeries();
            BMI_Collection = new SeriesCollection();
            Weight_Collection = new SeriesCollection();

            dates = new String[logicRef.getWeightAndBMIData(mainWindow.SoSecNb).Count];

            //Opretter alle mine linjer med den korrekte værdi (her int)
            line_Weight.Values = new ChartValues<int>();
            line_BMI.Values = new ChartValues<int>();

            //Tilføje titler til mine linjer
            line_BMI.Title = "BMI";
            line_Weight.Title = "Vægt";

            //Ændrer farven
            Weight_Collection.Add(line_Weight);
            BMI_Collection.Add(line_BMI);
        }

        private void addBlodpreasure(MainWindow mainWindow, Logic logicRef)
        {
            for (int i = 0; i < logicRef.getWeightAndBMIData(mainWindow.SoSecNb).Count; i++)
            {
                line_BMI.Values.Add(logicRef.getWeightAndBMIData(mainWindow.SoSecNb)[i].BMI_);
                //line_Weight.Values.Add(logicRef.getWeightAndBMIData(mainWindow.SoSecNb)[i].Weight_);

                //Min lables til x-axen
                dates[i] = logicRef.getWeightAndBMIData(mainWindow.SoSecNb)[i].Date_.ToString("dd/MM/yyyy");
            }
        }
    }
}
