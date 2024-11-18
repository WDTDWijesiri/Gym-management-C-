using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Interaction logic for Forgotpass.xaml
    /// </summary>
    public partial class Forgotpass : Window
    {
        string randamcode;
        public static string to;
        public Forgotpass()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, RoutedEventArgs e, message message)
        {
           
        }

        private void btn_verify_Click(object sender, RoutedEventArgs e)
        {
            if (randamcode == (txt_code.Text).ToString())
            {
                to=txt_email.Text;
                ResetPassword resetPassword = new ResetPassword();
                this.Hide();
                resetPassword.Show();
            }
            else
            {
                MessageBox.Show("Worng code");
            }
        }

        private void btn_code_Click(object sender, RoutedEventArgs e)
        {
            string from, pass, messagebody;
            Random rand = new Random();
            randamcode = (rand.Next(999999)).ToString();
            MailMessage mailmessage = new MailMessage();
            to = (txt_email.Text).ToString();
            from = "thanujadilhara545@gmail.com";
            pass = "1234@";
            messagebody = $"Your reset code is{randamcode}";
            mailmessage.To.Add(to);
            mailmessage.From = new MailAddress(from);
            mailmessage.Subject = "Password Reset Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(mailmessage);
                MessageBox.Show("Code successfully send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMinimize_clic(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
