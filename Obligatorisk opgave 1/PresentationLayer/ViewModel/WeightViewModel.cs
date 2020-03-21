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
    class WeightViewModel
    {
        public SeriesCollection BMI_Collection { get; set; }
        public SeriesCollection Weight_Collection { get; set; }
        //private String explanation = "Systole er et udtryk for det laveste";
        //public String Explanation { get { return explanation; set{ Explanation } }

        private LineSeries line_BMI, line_Weight = new LineSeries();

        public String[] Dates { get; set; }
        public WeightViewModel(MainWindow mainWindow, Logic logicRef)
        {
            CreateChart(mainWindow, logicRef);
            AddBlodpreasure(mainWindow, logicRef);
        }
        private void CreateChart(MainWindow mainWindow, Logic logicRef)
        {
            line_BMI = new LineSeries { };
            line_Weight = new LineSeries();
            BMI_Collection = new SeriesCollection();
            Weight_Collection = new SeriesCollection();

            Dates = new String[logicRef.getWeightAndBMIData(mainWindow.SocSecNb).Count];

            //Opretter alle mine linjer med den korrekte værdi (her int)
            line_Weight.Values = new ChartValues<double>();
            line_BMI.Values = new ChartValues<int>();

            //Tilføje titler til mine linjer
            line_BMI.Title = "BMI";
            line_Weight.Title = "Vægt";
            
            
            //Ændrer farven
            Weight_Collection.Add(line_Weight);
            BMI_Collection.Add(line_BMI);

            
        }

        private void AddBlodpreasure(MainWindow mainWindow, Logic logicRef)
        {
            for (int i = 0; i < logicRef.getWeightAndBMIData(mainWindow.SocSecNb).Count; i++)
            {
                line_BMI.Values.Add(logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].BMI_);
                line_Weight.Values.Add(logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].Weight_); //Det her virker ikke?

                //Min lables til x-axen
                Dates[i] = logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].Date_.ToString("dd/MM/yyyy");
            }
        }
    }
}
