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
using System.Windows.Threading;

namespace NosaczTheGame
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //tworzenie timera do liczenia 
            DispatcherTimer czas = new DispatcherTimer();
            czas.Interval= TimeSpan.FromSeconds(1);
            czas.Tick += Czas_Tick;
            czas.Start();
            

        }

        private void Czas_Tick(object sender, EventArgs e)
        {
           // Czas.Content = DateTime.Now.ToLongTimeString();
        }

        private void DotknijNosacza_Click(object sender, RoutedEventArgs e)
        {
          /*  Image nosacz;  
            nosacz. */
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
          //  MessageBox.Show("cycuszki");
        
        }

        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
           // MessageBox.Show("masło");
        }
        static int punkty;
        static bool passat = false;
        static bool halineczka = false;
        static bool urlopNadMorzem = false;
        static int WygranyKupon = 0;
        Image nowaCebula = new Image();

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //  var ile = Pismo.Text;


            punkty += 1;
            if (passat == true)
            {
                punkty += 9;
            }
            if (halineczka == true)
            {
                punkty += 3;
            }
            if (urlopNadMorzem == true)
            {
                punkty += 25;
            }
            if (WygranyKupon >= 100)
            {
                MessageBox.Show("Wygrałeś milion", "wygryw Życia", MessageBoxButton.OK, MessageBoxImage.Stop);
                punkty = 1000000;
            }

            /*   if (halineczka == true && passat == true)
               {
                   punkty += 5;
               } */
            //  Image ii = (Image)sender;
            LabelPunkty.Content = punkty;
            //Punktyy.Text = Convert.ToString(punkty);

            if (punkty >= 3)
            {
                Kupon.IsEnabled = true;

            }
            if (punkty >= 50)
            {
                if (halineczka == false)
                {
                    Halyna.IsEnabled = true;
                }
            }
            if (punkty == 100)
            {
                //MessageBox.Show("Zebrałeś 100 cebul","Wygrałeś życie!", MessageBoxButton.OK,MessageBoxImage.Information);
            }
            if (punkty >= 3000)
            {
                if (urlopNadMorzem == false)
                {
                    urlopik.IsEnabled = true;
                }
            }
            if (punkty >= 1500)
            {
                if (passat == false)
                {
                    Passat.IsEnabled = true;
                }
            }
            if (punkty >= 1000000)
                {
                    MessageBox.Show("wygrałeś!!");
                }
            }
        
        private void Halyna_Click(object sender, RoutedEventArgs e)
        {
            Halynka halina = new Halynka();
            halina.ShowDialog();
            ZabierzPunkty(50);
            halineczka = true;
            Halyna.IsEnabled = false;
            zupaLabel.Content = "";
            //  zupaLabel.Foreground = Foreground."#FFBD3535";
            // Halyna.Visibility = Visibility.Collapsed;

            Gratulacje();
        }

        private void Passat_Click(object sender, RoutedEventArgs e)
        {
            Passeratti pas = new Passeratti();
            pas.ShowDialog();
            passat = true;
            Passat.IsEnabled = false;
            ZabierzPunkty(1500);
            passatLabel.Content = "";
            //
            Gratulacje();
            
        }

        private void NowaCebula_Click(object sender, RoutedEventArgs e)
        {
            /*  var Uri = new Uri("D:\\nosacz the game\\cebula.jpg");
              nowaCebula.Source = new BitmapImage(Uri);
              //nowaCebula.Visibility
              nowaCebula.MaxWidth = 20;
              nowaCebula.MaxHeight = 30;
              // var marginesik = "72,136,0,0";
              //nowaCebula.Margin = marginesik;

              nowaCebula.Margin = new Thickness(72, 136, 0, 0);
              // nowaCebula.VerticalAlignment = TopProperty;
              // nowaCebula.HorizontalAlignment= 
              MessageBox.Show("żyję!"); */
         //   NowaCebulka.Visibility = Visibility.Visible;
        }

        private void NowaCebulka_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        /*    DispatcherTimer czasomierz= new DispatcherTimer();
            czasomierz.Interval = TimeSpan.FromSeconds(1);
            czasomierz.Tick += Czasomierz_Tick;
            czasomierz.Start();
            CzasCebuli.Visibility = Visibility.Visible;
            MessageBox.Show("OJ"); */
        }
        private void Czasomierz_Tick(object sender, EventArgs e)
        {
            // Czas.Content = DateTime.Now.ToLongTimeString();
         //   CzasCebuli.Content = 

        }

        private void Zadania_Click(object sender, RoutedEventArgs e)
        {
           /* ZadaniaDoZrobienia zadanka = new ZadaniaDoZrobienia();
            zadanka.ShowDialog(); */
        }
        //kupon
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZabierzPunkty(3);
            Lotto los = new Lotto();
            los.ShowDialog();
     
            WygranyKupon++;
            kuponik.Content = "";
            Gratulacje();
            // Gratulacje();

        }
        //urlopik
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ZabierzPunkty(3000);
            Wakacjecs wUrlop = new Wakacjecs();
            wUrlop.ShowDialog();
          
            urlopik.IsEnabled = false;
            wakacje.Content = "";
            Gratulacje();
        }
       private void Gratulacje()
        {
            UkonczonoMisje misja = new UkonczonoMisje();
            misja.Enabled = true;
            misja.ShowDialog();
            dajPunkty(500);

        }
        private void dajPunkty(int ile)
        {
            punkty += ile;
            LabelPunkty.Content = punkty;

        }
        private void ZabierzPunkty(int ilePkt)
        {
            punkty -= ilePkt;
            LabelPunkty.Content = punkty;
        }
    }
}
