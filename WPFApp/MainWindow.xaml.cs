using EK7TKN_HFT_2021221.Client;
using EK7TKN_HFT_2021221.Models;
using Newtonsoft.Json;
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

        UserInformation currentUser { get; set; }

        RestService rest = new RestService("http://localhost:5000");

        public MainWindow()
        {
            
            InitializeComponent();

            currentUser = new UserInformation();

        }

        private void btn_show_loginwindow(object sender, RoutedEventArgs e)
        {
            Login_Screen loginscreen = new Login_Screen();


            if (loginscreen.ShowDialog() == true)
            {
                
                currentUser.Full_Name = loginscreen.user.name;
                name_lbl.Content = currentUser.Full_Name;

                currentUser.Weight = loginscreen.user.weight;
                weight_txb.Text = currentUser.Weight.ToString();

                currentUser.Height = (int)loginscreen.user.height;
                height_tb.Text = currentUser.Height.ToString();

                currentUser.Age = loginscreen.user.age;
                age_lbl.Text= currentUser.Age.ToString();

                currentUser.Email = loginscreen.user.email;
                email_lbl.Text = currentUser.Email.ToString();

                currentUser.UserID = loginscreen.user.userid;
                id_tb.Text = currentUser.UserID.ToString();

            }

        }



        private void btn_save_changes(object sender, RoutedEventArgs e)
        {
            currentUser.Full_Name = name_lbl.Content.ToString();
            currentUser.Weight = double.Parse(weight_txb.Text);
            currentUser.Height = int.Parse(height_tb.Text);
            currentUser.Age = int.Parse(age_lbl.Text);
            currentUser.Email = email_lbl.Text.ToString();
            currentUser.UserID = int.Parse(id_tb.Text);

            string jsonUser = JsonConvert.SerializeObject(currentUser);

            rest.Put<string>(jsonUser, $"user/put/{currentUser.UserID}");

        }
    }

   
   
}
