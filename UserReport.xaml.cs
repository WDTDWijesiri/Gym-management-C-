using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for UserReport.xaml
    /// </summary>
    public partial class UserReport : Window
    {
        public UserReport()
        {
            InitializeComponent();
        }
        DBLogic obj= new DBLogic();
        private void btn_report_Click(object sender, RoutedEventArgs e)
        {
            try
    {
        if (rdo_user_id.IsChecked == true)
        {
                    
            datagrid.ItemsSource = obj.Display("Select * from users where users_ID  = '" + txt_search.Text + "'").DefaultView;
        }
        else if (rdo_username.IsChecked == true)
        {
            datagrid.ItemsSource = obj.Display("Select * from users where Users_name LIKE '" + txt_search.Text + "%'").DefaultView; 
        }
        if (txt_search.Text.Length == 0)
        {
            datagrid.ItemsSource = obj.Display("Select * from Client").DefaultView;
        }
    }
    catch (Exception)
    {
        MessageBox.Show(this, "Please check again", "Error",
        MessageBoxButton.OK, MessageBoxImage.Error);
    }
        }

        private void btn_usReport_click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Home obj = new Home();
            obj.Show();
        }
    }

}
