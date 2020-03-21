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
        public BSWindow(MainWindow mainWindow, Logic logicRef)
        {
            InitializeComponent();
            mainWindow_ = mainWindow;
            DataContext = new BSViewModel(mainWindow_, logicRef);
        }

        private void BT_tilbage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow_.Show();
        }

   

        private void BSWindow1_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            mainWindow_.Show();

        }
    }
}
