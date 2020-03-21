using Logic_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for WeightWindow.xaml
    /// </summary>
    public partial class WeightWindow : Window
    {
        private Logic logicRef_;
        private MainWindow mainWindow_;
        private bool showWordExplanations { get; set; }

        public WeightWindow(MainWindow mainWindow, Logic logicRef)
        {
            logicRef_ = logicRef;
            mainWindow_ = mainWindow;
            InitializeComponent();

            //Databinder til min viewmodel hvor jeg vil oprette mine linjer
            DataContext = new WeightViewModel(mainWindow_, logicRef_);
            TBx_ordforklaringer.IsReadOnly = true;
            TBx_ordforklaringer.Text = "Dette er en lang testtekst der bliver gentaget \nDette er en lang testtekst der bliver gentaget \nDette er en lang testtekst der bliver gentaget \nDette er en lang testtekst der bliver gentaget \n";
        }

        private void BT_tilbage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow_.Show();
            showWordExplanations = false;
        }

        private void BT_ordforkaringer_Click(object sender, RoutedEventArgs e)
        {
            if (showWordExplanations)
            {
                TBx_ordforklaringer.Visibility = Visibility.Hidden;
                showWordExplanations = false;
            }
            else if(showWordExplanations == false)
            {

                TBx_ordforklaringer.Visibility = Visibility.Visible;
                showWordExplanations = true;
            }
            //Dit BMI(Body Mass Index) beskriver forholdet mellem din vægt og højde
        }

        private void WeightWindowName_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            mainWindow_.Show();
            showWordExplanations = false;
        }

        private void WeightWindowName_Loaded(object sender, RoutedEventArgs e)
        {
            TBx_ordforklaringer.Visibility = Visibility.Hidden;
        }

       
    }
}
