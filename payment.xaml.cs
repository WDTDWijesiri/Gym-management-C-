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
using System.Data.SqlClient;


namespace GYMorginalcopy
{
    /// <summary>
    /// Interaction logic for payment.xaml
    /// </summary>
    public partial class payment : Window
    {
        string combobox;
        SqlConnection con;
        SqlCommand cmd;
        public payment()
        {
            InitializeComponent();
            getUserID();
        }

        DBLogic obj=new DBLogic();

        private void btnMinimize_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void btnpay_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_amount.Text.Length==0 || txt_amount.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Amount cannot be blank or Amount cannot have lrtter","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                }
               else if (txt_NC.Text.Length == 0 || txt_NC.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("Card name cannot be blank or Card name cannot have numbers", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txt_Cnum.Text.Length == 0 || txt_Cnum.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Card number cannot be blank or card number cannot have lrtter", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               else if (txt_cvv.Text.Length == 0 || txt_cvv.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("CVV cannot be blank or CVV cannot have lrtter", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               else if (txt_cvv.Text.Length >3)
                {
                    MessageBox.Show("CVV cannot be enter more than three numbers", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txt_EM.Text.Length == 0 || txt_EM.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Exprition month cannot be blank or Exprition month cannot have lrtter", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txt_EM.Text.Length > 2)
                {
                    MessageBox.Show("Exprition month cannot be enter more than three numbers", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txt_ey.Text.Length == 0 || txt_ey.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Exprition year cannot be blank or Exprition year cannot have lrtter", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (txt_ey.Text.Length > 4)
                {
                    MessageBox.Show("Exprition Year cannot be enter more than three numbers", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else {
                    if (com_methode.SelectedIndex == 0)
                    {
                        string q = "insert into Pay values ('" + cmb_id.SelectedItem + "','Online Payment', '" + txt_NC.Text + "', '" + txt_Cnum.Text + "','" + txt_amount.Text + "','" + txt_cvv.Text + "','" + txt_EM.Text + "','" + txt_ey.Text + "')";
                        int i = obj.save_update_delete(q);
                        if (i == 1)
                            MessageBox.Show(this, "Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                            MessageBox.Show(this, "Data Cannot Save", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        //error_msg 

                    }
                    else if (com_methode.SelectedIndex == 1)
                    {
                        string q = "insert into Pay values ('" + cmb_id.SelectedItem + "','Cridit Card', '" + txt_NC.Text + "', '" + txt_Cnum.Text + "','" + txt_amount.Text + "','" + txt_cvv.Text + "','" + txt_EM.Text + "','" + txt_ey.Text + "')";
                        int i = obj.save_update_delete(q);
                        if (i == 1)
                            MessageBox.Show(this, "Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                            MessageBox.Show(this, "Data Cannot Save", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (com_methode.SelectedIndex == 2)
                    {
                        string q = "insert into Pay values ('" + cmb_id.SelectedItem + "','Debit Card', '" + txt_NC.Text + "', '" + txt_Cnum.Text + "','" + txt_amount.Text + "','" + txt_cvv.Text + "','" + txt_EM.Text + "','" + txt_ey.Text + "')";
                        int i = obj.save_update_delete(q);
                        if (i == 1)
                            MessageBox.Show(this, "Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                            MessageBox.Show(this, "Data Cannot Save", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (com_methode.SelectedIndex == 3)
                    {
                        string q = "insert into Pay values ('" + cmb_id.SelectedItem + "','Cash', '" + txt_NC.Text + "', '" + txt_Cnum.Text + "','" + txt_amount.Text + "','" + txt_cvv.Text + "','" + txt_EM.Text + "','" + txt_ey.Text + "')";
                        int i = obj.save_update_delete(q);
                        if (i == 1)
                            MessageBox.Show(this, "Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        else
                            MessageBox.Show(this, "Data Cannot Save", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getUserID()
        {
            try
            {

                con = new SqlConnection("Data Source=THANUJA;Initial Catalog=GYM;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand("select users_ID from users", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cmb_id.Items.Add(dr[0].ToString());
                }
                con.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
