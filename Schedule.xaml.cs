using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Drawing;
using ZXing;

namespace GYMorginalcopy
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    ///
    public partial class Schedule : Window
    {
        string combobox;
        SqlConnection con ;
        SqlCommand cmd;
        public Schedule()
        {
            InitializeComponent();
            getUserID();
        }
        DBLogic obj =new DBLogic();
        private void getUserData()
        {
            try
            {
                con = new SqlConnection("Data Source=THANUJA;Initial Catalog=GYM;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand("select Users_age, U_Height, U_Weight from users where users_ID = '"+cmb_id.SelectedItem+"'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    txt_age.Text = Convert.ToString(dr["Users_age"]);
                    txt_height.Text = Convert.ToString(dr["U_Height"]);
                    txt_weight.Text = Convert.ToString(dr["U_Weight"]);
                }
                con.Close();
            }
            catch
            { 
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
        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txt_age.Text.Length==0||txt_age.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Age cannot be blank or age cannot enter letter");
                }
                else if (txt_day.Text.Length == 0 || txt_day.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Day cannot be blank or Day cannot enter letter");
                }
                else if (txt_bmi.Text.Length == 0 || txt_bmi.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("BMI cannot be blank or BMI cannot enter letter");
                }
                else if (txt_height.Text.Length == 0 || txt_height.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Height cannot be blank or Height cannot enter letter");
                }
                else if (txt_weight.Text.Length == 0 || txt_weight.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Weight cannot be blank or Weight cannot enter letter");
                }
                else if (txt_reps.Text.Length == 0 || txt_reps.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Reps cannot be blank or Reps cannot enter letter");
                }
                else if (txt_sets.Text.Length == 0 || txt_sets.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Sets cannot be blank or Sets cannot enter letter");
                }
                else if (txt_sDay.Text.Length == 0 || txt_sDay.Text.Any(char.IsLetter))
                {
                    MessageBox.Show("Day cannot be blank or Day cannot enter letter");
                }
                else
                {
                    //string q = "Insert into Trainer values ('" + cmb_id.SelectedItem+"''" + txt_day.Text + "','" + txt_age.Text + "','" + txt_height.Text + "','" + txt_weight.Text + "','" + txt_bmi.Text + "','" + txt_sDay.Text + "','" + txt_exercise.Text + "','" + txt_reps.Text + "','" + txt_sets.Text + "')";
                    string q = "insert into Schedule values ('" + cmb_id.SelectedItem + "', '" + txt_day.Text + "', '" + txt_age.Text + "', '" + txt_height.Text + "','" + txt_weight.Text + "','" + txt_bmi.Text + "','" + txt_sDay.Text + "','" + txt_exercise.Text + "','" + txt_reps.Text + "','" + txt_sets.Text + "')";
                    int i = obj.save_update_delete(q);
                    if (i == 1)
                        MessageBox.Show(this, "Data save Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show(this, "Data Cannot Save", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    //error_msg 

                }

            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getUserData();
        }

        private void btnMinimize_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_close_click(object sender, RoutedEventArgs e)
        {
            Thome thome = new Thome();  
            thome.Show();
            this.Close();
        }
    }
}
