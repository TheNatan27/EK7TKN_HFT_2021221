using EK7TKN_HFT_2021221.Client;
using EK7TKN_HFT_2021221.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private string sessionPassword;
        private int sessionUserID;
        List<KeyValuePair<double, string>> currentRuns;
        ObservableCollection<KeyValuePair<double, string>> runs;

        RestService rest = new RestService("http://localhost:5000");

        public MainWindow()
        {
            
            InitializeComponent();

            currentUser = new UserInformation();

            runs = new ObservableCollection<KeyValuePair<double, string>>();

            runs_list.ItemsSource = runs;


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

        private void btn_login(object sender, RoutedEventArgs e)
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
                age_lbl.Text = currentUser.Age.ToString();

                currentUser.Email = loginscreen.user.email;
                email_lbl.Text = currentUser.Email.ToString();

                currentUser.UserID = loginscreen.user.userid;
                id_tb.Text = currentUser.UserID.ToString();

                currentRuns = loginscreen.user.runs;

                runs.Clear();

                foreach (var item in currentRuns)
                {
                    runs.Add(item);
                }
                

                sessionUserID = loginscreen.user.userid;
                sessionPassword = loginscreen.user.pass;


            }
        }

        private void btn_refresh(object sender, RoutedEventArgs e)
        {
            var sessionPassword = rest.Get<PasswordSecurity>(sessionUserID, "pass/read");
            var sessionUser = rest.Get<UserInformation>(sessionUserID, "user/read");

            currentUser.Full_Name = sessionUser.Full_Name;
            name_lbl.Content = currentUser.Full_Name;

            currentUser.Weight = sessionUser.Weight;
            weight_txb.Text = currentUser.Weight.ToString();

            currentUser.Height = sessionUser.Height;
            height_tb.Text = currentUser.Height.ToString();

            currentUser.Age = sessionUser.Age;
            age_lbl.Text = currentUser.Age.ToString();

            currentUser.Email = sessionUser.Email;
            email_lbl.Text = currentUser.Email.ToString();

            currentUser.UserID = sessionUser.UserID;
            id_tb.Text = currentUser.UserID.ToString();
        }
    }

   
   
}
