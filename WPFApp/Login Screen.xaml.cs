using EK7TKN_HFT_2021221.Client;
using EK7TKN_HFT_2021221.Models;
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

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for Login_Screen.xaml
    /// </summary>
    public partial class Login_Screen : Window
    {
        RestService rest = new RestService("http://localhost:5000");
        public SessionUser user { get; set; }
        public Login_Screen()
        {

            InitializeComponent();

        }

        private void btn_login(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(userid_txb.Text);
            string password = password_txb.Text;

            login_confirmation(id, password);

        }

        private void login_confirmation(int id, string password)
        {

            var sessionPassword = rest.Get<PasswordSecurity>(id, "pass/read");
            var sessionUser = rest.Get<UserInformation>(id, "user/read");

            string cleanpass = sessionPassword.TotallySecuredVeryHashedPassword.Trim();

            if (id == sessionPassword.UserId && cleanpass == password)
            {
                user = new SessionUser
                {
                    name = sessionUser.Full_Name,
                    email = sessionUser.Email,
                    weight = sessionUser.Weight,
                    height = sessionUser.Height,
                    userid = sessionUser.UserID,
                    ispremium = sessionUser.Premium,
                    pass = cleanpass
                };

                DialogResult = true;
                //login succesfull
            }
            else
            {
                //login failed 
            }

        }
    }

    public class SessionUser
    {
        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public int userid { get; set; }
        public bool ispremium { get; set; }
        public string pass { get; set; }
    }
}
