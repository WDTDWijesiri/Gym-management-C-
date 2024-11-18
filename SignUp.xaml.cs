using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Window_moueDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; 
        }

        private void btnClose_click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnLogin_click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=THANUJA;Initial Catalog=GYM;Integrated Security=True");
            con.Open();
            string q = "select * from users where Users_name=@username and Password=@password";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@username", txtUser.Text);
            cmd.Parameters.AddWithValue("@password", txt_password.Password.ToString());

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                Home obj = new Home();
                obj.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect user name or password","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void btn_reset_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Forgotpass forgotpass = new Forgotpass();
            forgotpass.Show();
            
        }
    }
}
