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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private static MainWindow mainWindow_;
        private static Logic logicRef_;
        private bool erazing = true;
        private bool isInitialized = false;
        private String password = "";

        public LoginWindow(MainWindow mainWindow, Logic logicRef)
        {
            mainWindow_ = mainWindow;
            logicRef_ = logicRef;
            InitializeComponent();
            TB_username.Focus();
            TB_username.SelectAll();
        }

        private void Bn_login_Click(object sender, RoutedEventArgs e)
        {
            verifyLogin();
        }


        //Opretter en metode der verificerer logindet
        private void verifyLogin()
        {
            if (logicRef_.checkLogin(TB_username.Text, PWB_password.Password))
            {
                this.Close();
                mainWindow_.Show();
                mainWindow_.SoSecNb = TB_username.Text.ToString();
            }

            else
            {
                MessageBox.Show("Forkert brugernavn eller adgangskode");
                PWB_password.Password = "";
                TB_username.Focus();
                TB_username.SelectAll();
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                verifyLogin();
            }
        }

        private void TB_username_TextChanged(object sender, TextChangedEventArgs e)
        {
            //sørger for, at man hopper til kodeordsfeltet, hvis man har skrevet hele sit CPR nummer
            if (TB_username.Text.Length == 11 && isInitialized)
            {
                PWB_password.Focus();
            }

            if (TB_username.Text.Length == 6 && erazing == true)
            {
                TB_username.Text = TB_username.Text.ToString() + "-";
                TB_username.SelectionStart = TB_username.Text.Length;
                isInitialized = true;
                erazing = false;
            }
            if (TB_username.Text.Length < 6)
                erazing = true;
        }

        // Viser informations vinduet
        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            TB_info.Visibility = Visibility.Visible;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            TB_info.Visibility = Visibility.Hidden;
        }
    }
}
