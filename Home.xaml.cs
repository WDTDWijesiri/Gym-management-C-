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

namespace GYMorginalcopy
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        bool IsMaximized = false;

        private void Border_LeftMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1280;
                    this.Height = 780;

                    IsMaximized = false;

                }
                else
                {

                    this.WindowState = WindowState.Maximized;


                    IsMaximized = true;
                }
            }
            
         }

        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserReport userReport = new UserReport();
            userReport.Show();
            this.Close();

            
        }

        private void btn_logOut_click(object sender, RoutedEventArgs e)
        {
            
            SignUp login = new SignUp();
            login.Show();
            this.Close();
        }

        private void btn_payment_click(object sender, RoutedEventArgs e)
        {
            payment payment=new payment();
            payment.Show();
            this.Close ();
        }

        private void UserCard_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Qr_click(object sender, RoutedEventArgs e)
        {
            QrGeneretor qr=new QrGeneretor();
            qr.Show();
            this.Close();
        }

        private void textSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = textSearch.Text;
        }

        private void btn_profil_update(object sender, RoutedEventArgs e)
        {
            Update obj = new Update();
            obj.Show();
            this.Close();
        }

        private void Report_click(object sender, RoutedEventArgs e)
        {
            SchedulReport report = new SchedulReport();
            report.Show(); 
           
        }
    }
}
