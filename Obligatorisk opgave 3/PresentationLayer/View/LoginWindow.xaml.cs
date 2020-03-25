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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow mainWindow_;
        private Logic logicRef_;
        private bool madeMistake;
        private bool isInitialized;

        public LoginWindow(MainWindow mainWindow, Logic logicRef)
        {
            InitializeComponent();

            mainWindow_ = mainWindow;
            logicRef_ = logicRef;
            madeMistake = true;
            isInitialized = false;
            
            TBx_username.Focus();
            TBx_username.SelectAll();
            TBx_info.Text = "Dit personnummer er din \nfødselsdagsdato efterfulgt \naf 4 andre tal. \nDu kan finde dit CPR nummer \npå forsiden af dit \ngule sygesikringskort";
            TBx_infoPassword.Text = "Dit kodeord består af 4 tal, \nog er nogle du selv har valgt. \nHar du glent dit kodeord, \nså ring til egen læge";
            
        }

        private void Bn_login_Click(object sender, RoutedEventArgs e)
        {
            //Jeg har valgt at lave dette som en metode, fordi jeg bruge den samme kode to gange i dette vindue.
            verifyLogin();
        }


        //Opretter en metode der verificerer login'et
        private void verifyLogin()
        {
            if (logicRef_.checkLogin(TBx_username.Text, PWB_password.Password))
            {
                this.Close();
                mainWindow_.Show();
                mainWindow_.SocSecNb = TBx_username.Text.ToString();
            }

            else
            {
                MessageBox.Show("Forkert brugernavn eller adgangskode");
                PWB_password.Password = "";
                Ll_forkertLogin.Visibility = Visibility.Visible;
                TBx_username.Focus();
                TBx_username.SelectAll();
                PWB_password.BorderBrush = Brushes.Transparent;
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //Når man trykker på enter skal denne kode køres. Ellers har keyboardet ingen funktinalitet i loginvinduet
            if (e.Key == Key.Return)
            {
                //Jeg har valgt at lave dette som en metode, fordi jeg bruge den samme kode to gange i dette vindue.
                verifyLogin();
            }
        }

        private void TB_username_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            //sørger for, at man hopper til kodeordsfeltet, hvis man har skrevet hele sit CPR nummer
            //Dette er en semi god designfeature, fordi man måske forvirrer det ældre menneske hvis denne pludselig hopper rundt i vinduet men meget dejligt for alle andre
            if (TBx_username.Text.Length == 11 && isInitialized)
            {
                PWB_password.Focus();
            }

            //Her sættes stregen i CPR'nummeret automatisk. 
            if (TBx_username.Text.Length == 6 && madeMistake == true)
            {
                TBx_username.Text += "-";
                TBx_username.SelectionStart = TBx_username.Text.Length;

                //sørger for at man ikke springer direkte i password feltet når man skriver kvag funktionaliteten med at springe til kodefeltet når længden er 11
                isInitialized = true;

                //madeMistake boolen gør det muligt at slette igen
                madeMistake = false;
            }

            //gør det muligt at sætte bindestregen igen
            if (TBx_username.Text.Length <= 6)
            {
                madeMistake = true;
            }
        }
        

        //Eventhandler til Luk knappen i loginvinduet
        private void Bn_Luk_Click(object sender, RoutedEventArgs e)
        {
            mainWindow_.Close();
            this.Close();
        }

        //Disse fire eventhandlers har funktionaliteten af hjælpefunktionen. Det er når netop når musen træder ind eller ud af tekstfeltet at tekstboxen bliver vist.
        //Der er 2 pr. spørgsmålstegn (hhv leave og enter)
        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            TBx_info.Visibility = Visibility.Visible;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            TBx_info.Visibility = Visibility.Hidden;
        }

        private void Label_MouseEnter1(object sender, MouseEventArgs e)
        {
            TBx_infoPassword .Visibility = Visibility.Visible;
        }

        private void Label_MouseLeave1(object sender, MouseEventArgs e)
        {
            TBx_infoPassword.Visibility = Visibility.Hidden;
        }

    }
}
