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
                age_lbl.Content = currentUser.Age.ToString();

                currentUser.Email = loginscreen.user.email;
                email_lbl.Text = currentUser.Email.ToString();

                currentUser.UserID = loginscreen.user.userid;
                id_tb.Content = currentUser.UserID.ToString();

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            currentUser.Full_Name = name_lbl.Content.ToString();
            currentUser.Weight = double.Parse(weight_txb.Text);
            currentUser.Height = int.Parse(height_tb.Text);
            currentUser.Age = (int)age_lbl.Content;
            currentUser.Email = email_lbl.Text.ToString();
            currentUser.UserID = (int)id_tb.Content;

            string jsonUser = JsonConvert.SerializeObject(currentUser);

            rest.Put<string>(jsonUser, $"user/put/{currentUser.UserID}");
        }
    }

    //Console.WriteLine("Enter full name:");
    //        string first = Console.ReadLine();
    //Console.WriteLine("Enter age: ");
    //        int age = int.Parse(Console.ReadLine());
    //Console.WriteLine("Enter weight: ");
    //        double weight = double.Parse(Console.ReadLine());
    //Console.WriteLine("Enter height: ");
    //        int height = int.Parse(Console.ReadLine());
    //Console.WriteLine("Enter email: ");
    //        string email = Console.ReadLine();

    //Console.WriteLine("Enter the id of user you would like to update: ");
    //        int id = int.Parse(Console.ReadLine());

    //UserInformation newUser = new UserInformation()
    //{
    //    Full_Name = first,
    //    Age = age,
    //    Weight = weight,
    //    Height = height,
    //    Email = email
    //};

    //string jsonUser = JsonConvert.SerializeObject(newUser);

    //rest.Put<string>(jsonUser, $"user/put/{id}");
    //        Console.WriteLine(" <==  Press enter to go back");
    //        Console.ReadLine();
   
}
