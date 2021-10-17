using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Models
{
    class Program
    {
        static void Main(String[] args)
        {

            UserInformationContext use = new UserInformationContext();

            use.Users.Add(new UserInformation() { UserID = 01, Weight = 77 });
            use.Users.Add(new UserInformation() { UserID = 02, Weight = 55 });
            use.Users.Add(new UserInformation() { UserID = 03, Weight = 79 });
            use.Users.Add(new UserInformation() { UserID = 04, Weight = 87 });

            use.SaveChanges();

            foreach (var item in use.Users)
            {
                Console.WriteLine(item.UserID + item.Weight);
            }


        }
    }
}
