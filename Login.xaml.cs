using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            //Home ibj = new Home();
            //ibj.Show();
            SqlConnection con = new SqlConnection("Data Source=THANUJA;Initial Catalog=GYM;Integrated Security=True");
            con.Open();
            string q = "select * from users where Users_name=@username and Password=@password";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@username", txt_uname.Text);
            cmd.Parameters.AddWithValue("@password", psd_password.Password.ToString());

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {

                Home obj = new Home();
                obj.Show();
                this.Close();
            }
            else {
                error_msg.Content = "Incorrect user name or password";
            }
            
        }

        private void btn_signUp_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Registration obj = new Registration();
            obj.Show();
        }

        private void btn_show_Click(object sender, RoutedEventArgs e)
        {
            //if (psd_password.PasswordChar == '*')
            //{
            //    btn_show.BringIntoView();
            //    psd_password.PasswordChar = '\0';
            //}
        }

        private void btn_disabal_Click(object sender, RoutedEventArgs e)
        {
            //if (psd_password.PasswordChar == '\0')
            //{
            //    btn_show.BringIntoView();
            //    psd_password.PasswordChar = '*';
            //}
        }
    }
}
