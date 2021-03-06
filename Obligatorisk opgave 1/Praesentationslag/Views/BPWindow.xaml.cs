﻿using System;
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
using LiveCharts;
using LiveCharts.Wpf;
using Logic_Layer;

namespace Praesentationslag
{
    /// <summary>
    /// Interaction logic for BPWindow.xaml
    /// </summary>
    public partial class BPWindow : Window
    {
        private MainWindow mainWindow_;
        public BPWindow(MainWindow mainWindow, Logic logigRef)
        {
            mainWindow_ = mainWindow;
            InitializeComponent();
            DataContext = new BPViewModel(mainWindow, logigRef);
        }

        private void BT_tilbage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mainWindow_.Show();

        }
        private void BT_ordforkaringer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            mainWindow_.Show();
        }

    }
}
