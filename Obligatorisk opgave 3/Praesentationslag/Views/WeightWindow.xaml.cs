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
using Logic_Layer;


namespace Praesentationslag
{
    /// <summary>
    /// Interaction logic for WheightWindow.xaml
    /// </summary>
    public partial class WheightWindow : Window
    {
        private Logic logicRef_;
        private ViewModel viewMode_;
        private MainWindow mainWindow_;

        public WheightWindow(MainWindow mainWindow, Logic logicRef)
        {
            logicRef_ = logicRef;
            mainWindow_ = mainWindow;
            InitializeComponent();

            //Databinder til min viewmodel hvor jeg vil oprette mine linjer
            DataContext = new WeightViewModel(mainWindow_, logicRef_);
        }

        private void BT_tilbage_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow_.Show();
        }
    }
}
