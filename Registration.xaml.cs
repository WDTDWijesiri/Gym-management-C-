using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        string gender;
        public Registration()
        {
            InitializeComponent();
        }
        DBLogic obj=new DBLogic();
        SqlConnection con=new SqlConnection("Data Source=THANUJA;Initial Catalog=GYM;Integrated Security=True");
        string val = "u0";
        

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                //error_msg 

                if (txt_fname.Text.Length == 0 || txt_fname.Text.Any(char.IsDigit))
                    error_msg.Content = "First Name cannot be blank or First nemae cannot have number";
                else if (txt_lname.Text.Length == 0 || txt_lname.Text.Any(char.IsDigit))
                    error_msg.Content = "Last Name cannot be blank or Last nemae cannot have number";
                else if (txt_age.Text.Length == 0 || txt_age.Text.Any(char.IsLetter))
                    error_msg.Content = "Age cannot be blank or Age cannot have letters";
                else if (txt_weight.Text.Length == 0 || txt_weight.Text.Any(char.IsLetter))
                    error_msg.Content = "Weight cannot be blank or Weight cannot have letters";
                else if (txt_height.Text.Length == 0 || txt_height.Text.Any(char.IsLetter))
                    error_msg.Content = "Height cannot be blank or Height cannot have letters";
                else if (txt_email.Text.Length == 0)
                    error_msg.Content = "Email cannot be blank ";
                else if (!Regex.IsMatch(txt_email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                    error_msg.Content = "Enter a valid email. Ex:name@gmail.com";
                else if (txt_address.Text.Length == 0)
                    error_msg.Content = "Address cannot be blank ";
                else if (txt_tp.Text.Length == 0)
                    error_msg.Content = "Contact number cannot be blank ";
                else if (!Regex.IsMatch(txt_tp.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                    error_msg.Content = "TP must have 10 numbers";
                else if (psd_password.Password.Length == 0)
                    error_msg.Content = "Please Enter your Password";

                else if (psd_Cpassword.Password.Length == 0)
                    error_msg.Content = "Please Enter your Confirm Password";
                else if (psd_password.Password != psd_Cpassword.Password)
                    error_msg.Content = "Confirm Password must same as the Password";
                else
                {
                    if (rod_male.IsChecked==true)
                    {
                        string q = "Insert into users values ('" + txt_id.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_user.Text + "','" + txt_age.Text + "','" + txt_weight.Text + "','" + txt_height.Text + "','Male','" + txt_email.Text + "','" + txt_address.Text + "','" + txt_tp.Text + "','" + psd_password.Password + "','" + psd_Cpassword.Password + "')";
                        int i = obj.save_update_delete(q);
                        if (i == 1)
                            MessageBox.Show(this, "Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                            MessageBox.Show(this, "Data Cannot Save", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if(rod_female.IsChecked==true)
                    {
                        string q = "Insert into users values ('" + txt_id.Text + "','" + txt_fname.Text + "','" + txt_lname.Text + "','" + txt_user.Text + "','" + txt_age.Text + "','" + txt_weight.Text + "','" + txt_height.Text + "','Female','" + txt_email.Text + "','" + txt_address.Text + "','" + txt_tp.Text + "','" + psd_password.Password + "','" + psd_Cpassword.Password + "')";
                        int i = obj.save_update_delete(q);
                        if (i == 1)
                            MessageBox.Show(this, "Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                            MessageBox.Show(this, "Data Cannot Save", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }



            }
            catch (FormatException)
            {
                MessageBox.Show("invalid inputs types", "Erroe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Login obj = new Login();
            obj.Show();
        }
        public void Auto()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(users_ID)from users", con);
            int i=Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            txt_id.Text=val+i.ToString();
        }

        private void Registration_Load(object sender, RoutedEventArgs e)
        {
            Auto();
        }

        //private void btn_disabal_Click(object sender, RoutedEventArgs e)
        //{
        //    if(psd_password.PasswordChar=='*')
        //    {
        //        btn_show.BringIntoView();
        //        psd_password.PasswordChar = '\0';
        //    }
        //}

        //private void btn_show_Click(object sender, RoutedEventArgs e)
        //{
        //    if (psd_Cpassword.PasswordChar == '\0')
        //    {
        //        btn_show.BringIntoView();
        //        psd_Cpassword.PasswordChar = '*';
        //    }
        //}

        private void rod_male_Checked(object sender, RoutedEventArgs e)
        {
            gender = "Male";
           
        }

        private void rod_female_Checked(object sender, RoutedEventArgs e)
        {
            gender = "Female";

        }

        private void btnMinimize_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
