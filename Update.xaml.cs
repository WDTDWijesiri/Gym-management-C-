using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GYMorginalcopy
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public Update()
        {
            InitializeComponent();
        }
        DBLogic obj=new DBLogic();
        private void btn_update_click(object sender, RoutedEventArgs e)
        {

       
            

        }

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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string q = "update users set U_Height='" + txt_Height.Text + "',U_Weight='" + txt_Weight.Text + "'where users_ID='" + txt_id.Text + "'";
                int i = obj.save_update_delete(q);
                if (i == 1)
                    System.Windows.MessageBox.Show(this, "Data update Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    System.Windows.MessageBox.Show(this, "Data Cannot UpDate", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }
    }
}
