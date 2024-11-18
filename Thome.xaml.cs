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
    /// Interaction logic for Thome.xaml
    /// </summary>
    public partial class Thome : Window
    {
        public Thome()
        {
            InitializeComponent();
        }

        private void btn_schedul_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Schedule schedule = new Schedule();
            schedule.Width = 800;
            schedule.Height = 550;
            schedule.Show();
        }

        private void btnminimize_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
