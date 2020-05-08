using LiveCharts;
using LiveCharts.Wpf;
using Logic_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PresentationLayer
{
    class BSViewModel
    {
        public SeriesCollection BS_Collection { get; set; }
        private LineSeries line_bloodSugar;
        public String[] Dates { get; set; }

        //Bruges til at skrive den forklarende tekst
        public String forklaring { get; set; }

        //EKSTRA TILBEHØR
        public double MinValueBS { get; set; }
        public double MaxValueBS { get; set; }

        public BSViewModel(MainWindow mainWindow, Logic logicRef)
        {
            CreateChart(mainWindow, logicRef);
            AddBlodsugar(mainWindow, logicRef);
            forklaring = "Grafen viser dit blodsukker. De forskellige zoner fortæller dig om dit blodsukker ligger normalt: \n\nBlå zone: Her ligger blodsukkeret normalt før et måltid \n\nGrøn zone: Her ligger blodsukkeret normalt  ca 1½ time efter et måltid \n\nDen grå kasse: her ligger blodsukkeret normalt ved sengetid \n\nRød zone: Her er blodsukkeret hhv for højt eller for lavt. ";
        }

        private void CreateChart(MainWindow mainWindow, Logic logicRef)
        {
            line_bloodSugar = new LineSeries();
            BS_Collection = new SeriesCollection();

            Dates = new String[logicRef.getBSugarData(mainWindow.SocSecNb).Count];

            //Opretter alle mine linjer med den korrekte værdi (her double)
            line_bloodSugar.Values = new ChartValues<double>();

            //Tilføje titler til min linje
            line_bloodSugar.Title = "Blodsukker";
            line_bloodSugar.Stroke = Brushes.DarkBlue;
            line_bloodSugar.Fill = Brushes.Transparent;

            BS_Collection.Add(line_bloodSugar);
        }

        //Henter alt data fra Logiv og smider det ind i mine linjer
        private void AddBlodsugar(MainWindow mainWindow, Logic logicRef)
        {
            MinValueBS = logicRef.getBSugarData(mainWindow.SocSecNb)[0].BloodSugar_;
            MaxValueBS = logicRef.getBSugarData(mainWindow.SocSecNb)[0].BloodSugar_;

            for (int i = 0; i < logicRef.getBSugarData(mainWindow.SocSecNb).Count; i++)
            {
                line_bloodSugar.Values.Add(logicRef.getBSugarData(mainWindow.SocSecNb)[i].BloodSugar_);

                //Mine lables til x-axen
                Dates[i] = logicRef.getBSugarData(mainWindow.SocSecNb)[i].Date_.ToString("dd/MM/yyyy hh:mm");
                
                
                //EKSTRA TILBEHØR
                //Finder max og min værdi for mine akser
                if (MinValueBS > logicRef.getBSugarData(mainWindow.SocSecNb)[i].BloodSugar_)
                    MinValueBS = logicRef.getBSugarData(mainWindow.SocSecNb)[i].BloodSugar_;

                if (MaxValueBS < logicRef.getBSugarData(mainWindow.SocSecNb)[i].BloodSugar_)
                    MaxValueBS = logicRef.getBSugarData(mainWindow.SocSecNb)[i].BloodSugar_;

            }

            //EKSTRATILBEHØR
            MinValueBS -= 2;
            MaxValueBS += 2;
            
        }
    }
}
