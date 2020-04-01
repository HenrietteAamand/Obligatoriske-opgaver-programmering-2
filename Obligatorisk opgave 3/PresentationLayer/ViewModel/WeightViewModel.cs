using LiveCharts;
using LiveCharts.Wpf;
using Logic_Layer;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PresentationLayer
{
    class WeightViewModel
    {
        public SeriesCollection BMI_Collection { get; set; }
        public SeriesCollection Weight_Collection { get; set; }

        private LineSeries line_BMI, line_Weight;
        public String[] Dates { get; set; }

        //EKSTRA TILBEHØR
        public double MinValueBMI { get; set; }
        public double MaxValueBMI { get; set; }
        public double MinValueWeight { get; set; }
        public double MaxValueWeight { get; set; }

        //Bruges til at skrive den forklarende tekst
        public String forklaring { get; set; }

        public WeightViewModel(MainWindow mainWindow, Logic logicRef)
        {
            CreateChart(mainWindow, logicRef);
            AddWeightAndBMI(mainWindow, logicRef);
            forklaring = "Grafen til venstre viser din vægt i kg. Grafen til højre viser dit BMI. \nBMI (Body Mass Index) beskriver forholdet mellem din vægt og højde. Det kan fortælle dig, om du vejer for lidt eller for meget: \n\nBlå zone: Undervægtig \nGrøn zone: Normalvægtig \nGul zone: let overvægtig \nRødzone: Svært overvægtig";
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
            line_BMI.Values = new ChartValues<double>();

            //Tilføje titler til mine linjer
            line_BMI.Title = "BMI";
            line_BMI.Stroke = Brushes.Black;
            line_BMI.Fill = Brushes.Transparent;

            line_Weight.Title = "Vægt";
            line_Weight.Stroke = Brushes.DarkBlue;
            line_Weight.Fill = Brushes.Transparent;

            //Ændrer farven
            Weight_Collection.Add(line_Weight);
            BMI_Collection.Add(line_BMI);

            
        }

        //Henter alt data fra Logiv og smider det ind i mine linjer
        private void AddWeightAndBMI(MainWindow mainWindow, Logic logicRef)
        {
            MinValueBMI = logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[0].BMI_;
            MaxValueBMI = logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[0].BMI_;
            MinValueWeight = logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[0].Weight_;
            MaxValueWeight = logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[0].Weight_;

            for (int i = 0; i < logicRef.getWeightAndBMIData(mainWindow.SocSecNb).Count; i++)
            {
                line_BMI.Values.Add(logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].BMI_);
                line_Weight.Values.Add(logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].Weight_); //Det her virker ikke?

                //Min lables til x-axen
                Dates[i] = logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].Date_.ToString("dd/MM/yyyy");

                //EKSTRA TILBEHØR
                //Finder max og min værdi for mine akser
                if (MinValueBMI > logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].BMI_)
                    MinValueBMI = logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].BMI_;

                if (MaxValueBMI < logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].BMI_)
                    MaxValueBMI = logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].BMI_;

                if (MinValueWeight > logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].Weight_)
                    MinValueWeight = logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].Weight_;

                if (MaxValueWeight < logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].Weight_)
                    MaxValueWeight = logicRef.getWeightAndBMIData(mainWindow.SocSecNb)[i].Weight_;
            }

            //EKSTRATILBEHØR
            MinValueBMI -= 2;
            MaxValueBMI += 2;
            MinValueWeight -= 2;
            MaxValueWeight += 2;

        }
    }
}
