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
    /// Interaction logic for BPWindow.xaml
    /// </summary>
    public partial class BPWindow : Window
    {
        private MainWindow mainWindow_;
        private bool showWordExplanations { get; set; }
        public BPWindow(MainWindow mainWindow, Logic logigRef)
        {
            mainWindow_ = mainWindow;
            InitializeComponent();
            DataContext = new BPViewModel(mainWindow, logigRef);
        }

        private void Bn_tilbage_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow_.Show();

        }

        private void BPwindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainWindow_.Show();
        }

        //Viser og skjuler forklaringerne på graferne
        private void Bn_ordforkaringer_Click(object sender, RoutedEventArgs e)
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
        }
    }
}
