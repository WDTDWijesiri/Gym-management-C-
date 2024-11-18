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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GYMorginalcopy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Hide();
        //    SignUp obj = new SignUp();
        //    obj.Show();
        //}

        //private void btn_trainer_Click(object sender, RoutedEventArgs e)
        //{
        //    Hide();
        //    TrainerLogin obj = new TrainerLogin();
        //    obj.Show();
        //}

        //private void btn_register_Click(object sender, RoutedEventArgs e)
        //{
        //    Hide();
        //    Registration obj = new Registration();
        //    obj.Show();
        //}

        private void btn_user_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            SignUp obj = new SignUp();
            obj.Show();
        }

        private void btn_trainer_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            TrainerLogin obj = new TrainerLogin();
            obj.Show();
        }

        private void btn_registor_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Registration obj = new Registration();
            obj.Width = 800;
            obj.Height = 700;
            obj.Show();
        }
    }
}
