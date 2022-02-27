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

            var se = rest.Get<UserInformation>(id, "user/read");

            if (id == )
            {

            }

        }
    }

    public class SessionUser
    {
        public string name { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public int weight { get; set; }
        public double height { get; set; }
        public int userid { get; set; }
        public bool ispremium { get; set; }
    }
}
