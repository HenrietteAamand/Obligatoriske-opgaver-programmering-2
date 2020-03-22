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
    class BPViewModel
    {
        public SeriesCollection BP_Collection { get; set; }
        private LineSeries line_Systole, line_Diastole;
        public String[] Dates { get; set; }

        //Bruges til at skrive den forklarende tekst
        public String forklaring { get; set; }

        public BPViewModel(MainWindow mainWindow, Logic logicRef)
        {
            CreateChart(mainWindow, logicRef);
            AddBlodpreasure(mainWindow, logicRef);
            forklaring = "Normalt blodtryk anses som værende 120/80 hvor det høje tal er det systolske (den røde graf) og det lave er det diastolske (den blå graf). " +
                         "Jo ældre man bliver jo højere bliver ens blodtryk fordi blodårerne æderer sig med alderen. \n\n" +
                         "På grafen er to områder markeret: \n" +
                         "Når den røde graf ligger i det røde område anses det systolske blodtryk for normalt. \n" +
                         "Når den blå graf ligger i det blå område anses det diastolske blodtryk for normalt. ";
        }
        private void CreateChart(MainWindow mainWindow, Logic logicRef)
        {
            line_Diastole = new LineSeries { };
            line_Systole = new LineSeries();
            BP_Collection = new SeriesCollection();

            Dates = new String[logicRef.getBPressureData(mainWindow.SocSecNb).Count];

            //Diastole Linje
            line_Diastole.Values = new ChartValues<int>();
            line_Diastole.Title = "Diastolisk blodtryk";
            line_Diastole.Stroke = Brushes.DarkBlue;
            line_Diastole.Fill = Brushes.Transparent;

            //Systole linje
            line_Systole.Values = new ChartValues<int>();
            line_Systole.Title = "Systolisk blodtryk";
            line_Systole.Stroke = Brushes.DarkRed; 
            line_Systole.Fill = Brushes.Transparent;


            BP_Collection.Add(line_Systole);
            BP_Collection.Add(line_Diastole);
        }

        //Henter alt data fra Logiv og smider det ind i mine linjer
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
