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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading; 

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   //Tester lige ændringer
        private Logic logicRef_;
        private LoginWindow loginWindow;
        private BPWindow bPWindow;
        private BSWindow bSWindow;
        private WeightWindow weightWindow;
        public String SocSecNb { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            logicRef_ = new Logic();
            loginWindow = new LoginWindow(this, logicRef_);
        }



        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TBx_info.Text = "Her kan du finde oplysninger om dit blodsukker, dit blodtryk og din vægt.\n" +
                            "Tryk på en af knapperne nedenfor for at få vist informatiner og for at \n" +
                            "angive informationer for en ønsket ting. ";
            this.Hide();

            loginWindow.ShowDialog();
        }

        private void Bn_BLodtryk_Click(object sender, RoutedEventArgs e)
        {
            bPWindow = new BPWindow(this, logicRef_);
            this.Hide();
            bPWindow.ShowDialog();
        }

        private void Bn_Blodsukker_Click(object sender, RoutedEventArgs e)
        {
            bSWindow = new BSWindow(this, logicRef_);
            this.Hide();
            bSWindow.ShowDialog();
        }

        private void Bn_Vægt_Click(object sender, RoutedEventArgs e)
        {
            weightWindow = new WeightWindow(this, logicRef_);
            this.Hide();
            weightWindow.ShowDialog();
        }

        private void Bn_Send_Click(object sender, RoutedEventArgs e)
        {
            if(RBn_en.IsChecked == true)
            {
                MessageBox.Show($"Information fra 1 uge er sendt");
            }
            else if (RBn_to.IsChecked == true)
            {
                MessageBox.Show($"Information fra 2 uger er sendt");
            }
            else if (RBn_fire.IsChecked == true)
            {
                MessageBox.Show($"Information fra 4 uger er sendt");
            }
            else
                MessageBox.Show($"Ingen information sendt. Vælg antal uger du ønsker der skal sendes data fra og send igen");
        }

        private void Bn_Luk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
