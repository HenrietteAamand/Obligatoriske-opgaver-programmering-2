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
    {   
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
            Ll_info.Content = "Her kan du finde oplysninger om dit blodsukker, dit blodtryk og din vægt.\n" +
                              "Tryk på en af knapperne nedenfor for at få vist informatiner \nom det ønskede tema:";

            TBx_info.Text   = "Når du trykker på 'send', \n" +
                              "sender du informationer \n" +
                              "til din læge. \n" +
                              "Du sender informationer \n" + 
                              "svarende til antal uger, \n" +
                              "du har valgt i knapperne \n" +
                              "ovenfor";
            Ll_sendInfo.Content = "";
            this.Hide();

            loginWindow.ShowDialog();
        }

        private void Bn_BLodtryk_Click(object sender, RoutedEventArgs e)
        {
            //Jeg opretter vinduet hver gang fordi jeg ellers ikke kunne få lov til at bruge Close() kommandoen på de andre vinduer uden der kom en exception.
            bPWindow = new BPWindow(this, logicRef_);

            //sørger for at den røde tekst efter man har sendt info er væk når du kommer tilbage til dette vindue igen
            Ll_sendInfo.Content = ""; 
            this.Hide();
            bPWindow.ShowDialog();
        }

        private void Bn_Blodsukker_Click(object sender, RoutedEventArgs e)
        {
            //Jeg opretter vinduet hver gang fordi jeg ellers ikke kunne få lov til at bruge Close() kommandoen på de andre vinduer uden der kom en exception.
            bSWindow = new BSWindow(this, logicRef_);

            //sørger for at den røde tekst efter man har sendt info er væk når du kommer tilbage til dette vindue igen
            Ll_sendInfo.Content = "";
            this.Hide();
            bSWindow.ShowDialog();
        }

        private void Bn_Vægt_Click(object sender, RoutedEventArgs e)
        {
            //Jeg opretter vinduet hver gang fordi jeg ellers ikke kunne få lov til at bruge Close() kommandoen på de andre vinduer uden der kom en exception.
            weightWindow = new WeightWindow(this, logicRef_);

            //sørger for at den røde tekst efter man har sendt info er væk når du kommer tilbage til dette vindue igen
            Ll_sendInfo.Content = "";
            this.Hide();
            weightWindow.ShowDialog();
        }

        private void Bn_Send_Click(object sender, RoutedEventArgs e)
        {
            if(RBn_en.IsChecked == false && RBn_to.IsChecked == false && RBn_fire.IsChecked==false  && RBn_sendIkke.IsChecked == false)
            {
                MessageBox.Show("Du har ikke valgt nogen periode at sende information fra. Vælg periode og tryk send igen");
                Ll_sendInfo.Content = "";
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Er du sikker på du vil sende informationen?", "Send ", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (RBn_en.IsChecked == true)
                            Ll_sendInfo.Content = "Information fra 1 uge er sendt";
                        else if (RBn_to.IsChecked == true)
                            Ll_sendInfo.Content = "Information fra 2 uger er sendt";
                        else if (RBn_fire.IsChecked == true)
                            Ll_sendInfo.Content = "Information fra 4 uger er sendt";
                        else
                            Ll_sendInfo.Content = "Ingen information sendt. Vælg antal uger du \nønsker der skal sendes data fra og send igen";
                        break;

                    case MessageBoxResult.No:
                        Ll_sendInfo.Content = "Ingen information sendt";
                        break;
                }
            }
        }

        private void Bn_Luk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Bn_Logud_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil logge ud?", "Log ud af program", MessageBoxButton.YesNo );
            switch (result)
            {
                case MessageBoxResult.Yes:
                    //sørger for at den røde tekst efter man har sendt info er væk når du kommer tilbage til dette vindue hvis du vælger at logge ind igen
                    Ll_sendInfo.Content = ""; 
                    this.Hide();
                    loginWindow = new LoginWindow(this, logicRef_);
                    loginWindow.ShowDialog();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil lukke programmret?", "Luk program", MessageBoxButton.YesNo );
            switch (result)
            {
                case MessageBoxResult.Yes:
                    break;
                case MessageBoxResult.No:
                    e.Cancel = true;
                    break;
            }
        }

        //Disse to eventhandlers har funktionaliteten af hjælpefunktionen. Det er når netop når musen træder ind eller ud af tekstfeltet at tekstboxen bliver vist.
        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            TBx_info.Visibility = Visibility.Visible;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            TBx_info.Visibility = Visibility.Hidden;
        }
    }
}
