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


namespace Praesentationslag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logic logicRef_;
        LoginWindow loginWindow;
        BPWindow bPWindow;
        BSWindow bSWindow;
        WheightWindow weightWindow;


        public String SoSecNb { get; set; }
        public MainWindow()
        {
            logicRef_ = new Logic();
            InitializeComponent();
            loginWindow = new LoginWindow(this, logicRef_);
            bPWindow = new BPWindow(this, logicRef_);
            bSWindow = new BSWindow(this, logicRef_);
            weightWindow = new WheightWindow(this, logicRef_);

            DataContext = new ViewModel(this);

        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
            loginWindow.ShowDialog();
        }

        private void Bn_BLodtryk_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            bPWindow.ShowDialog();
        }

        private void Bn_Blodsukker_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            bSWindow.ShowDialog();
        }

        private void Bn_Vægt_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            weightWindow.ShowDialog();
        }
    }
}
