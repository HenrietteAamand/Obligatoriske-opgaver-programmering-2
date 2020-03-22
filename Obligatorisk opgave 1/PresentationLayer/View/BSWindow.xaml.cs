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
    /// Interaction logic for BSWindow.xaml
    /// </summary>
    public partial class BSWindow : Window
    {
        MainWindow mainWindow_;
        private bool showWordExplanations { get; set; }
        public BSWindow(MainWindow mainWindow, Logic logicRef)
        {
            InitializeComponent();
            mainWindow_ = mainWindow;
            DataContext = new BSViewModel(mainWindow_, logicRef);
        }

        private void Bn_tilbage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow_.Show();
        }

        private void Bn_forkaringer_Click(object sender, RoutedEventArgs e)
        {
            if (showWordExplanations)
            {
                Bn_ordforkaringer.Content = "Vis forklaring";
                TBx_ordforklaringer.Visibility = Visibility.Hidden;
                showWordExplanations = false;
            }
            else if (showWordExplanations == false)
            {
                Bn_ordforkaringer.Content = "Skjul forklaring";
                TBx_ordforklaringer.Visibility = Visibility.Visible;
                showWordExplanations = true;
            }
            //Dit BMI(Body Mass Index) beskriver forholdet mellem din vægt og højde
        }


        private void BSWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            mainWindow_.Show();

        }
    }
}
