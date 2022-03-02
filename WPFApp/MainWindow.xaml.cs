using EK7TKN_HFT_2021221.Client;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SessionUser user1 { get; set; }

        public MainWindow()
        {
            
            InitializeComponent();

            user1 = new SessionUser();

        }

        private void btn_show_loginwindow(object sender, RoutedEventArgs e)
        {
            Login_Screen loginscreen = new Login_Screen();

            Console.WriteLine(user1);
            Console.WriteLine();

            if (loginscreen.ShowDialog() == true)
            {
                
                user1.name = loginscreen.user.name;
                name_lbl.Content = user1.name;

                user1.weight = loginscreen.user.weight;
                weight_txb.Text = user1.weight.ToString();

                user1.height = loginscreen.user.height;
                height_tb.Text = user1.height.ToString();

                user1.age = loginscreen.user.age;
                age_lbl.Content = user1.age.ToString();

                user1.email = loginscreen.user.email;
                email_lbl.Text = user1.email.ToString();

                user1.userid = loginscreen.user.userid;
                id_tb.Content = user1.userid.ToString();

            }

        }
    }


   
}
