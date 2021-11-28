using EK7TKN_HFT_2021221.Client;
using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EK7TKN_HFT_2021221
{
    class Program
    {
        static void Main(string[] args)
        {
            #region testing, to be deleted 

            //xDbContext context = new xDbContext();
            //Repo_Run run = new Repo_Run(context);
            //Repo_User user = new Repo_User(context);
            //Repo_Password password = new Repo_Password(context);

            //Logic_Run rlogic = new Logic_Run(user, password, run);
            //Logic_User ulogic = new Logic_User(user, password, run);
            //Logic_Password plogic = new Logic_Password(user, password, run);


            //var ri =
            //logic.Read(1);
            //foreach (var item in ri)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("///////////");
            //logic.Update("testRun_Standard.txt", 1);

            //var ri2 =

            //foreach (var item in ri2)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("/////");

            //var se = logic.ReadAll();
            //foreach (var item in se)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine("--");
            //    Console.WriteLine(item.Location);
            //}

            //IQueryable<RunInformation> s1 =
            //rlogic.Read(1);
            //IQueryable<UserInformation> s2 =
            //ulogic.Read(1);
            //IQueryable<PasswordSecurity> s3 =
            //plogic.Read(1);

            //foreach (var item in s1)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in s2)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in s3)
            //{
            //    Console.WriteLine(item.PassId);
            //    Console.WriteLine(item.RecoverPhoneNumber);
            //    Console.WriteLine(item.TotallySecuredVeryHashedPassword);
            //}

            #endregion

            System.Threading.Thread.Sleep(2000);

            RestService rest = new RestService("http://localhost:5000");

            List<UserInformation> allusers = rest.GetAll<UserInformation>("user");
            List<RunInformation> allruns = rest.GetAll<RunInformation>("run");
            List<PasswordSecurity> allpass = rest.GetAll<PasswordSecurity>("password");

            List<string> user1 = rest.GetAll<string>("user/GetEmailOfWeakPasswordUsers");
            List<string> user2 = rest.GetAll<string>("user/GetCompetitorsEmailAddress");
            List<string> user3 = rest.GetAll<string>("user/GetAmericanUsersNames");
            List<string> user4 = rest.GetAll<string>("user/GetLongDistanceCompetitorsNames");
            List<string> user5 = rest.GetAll<string>("user/GetNameOfLongDistanceOldRunners");

            foreach (var item in user1)
            {
                Console.WriteLine(item.Trim());
            }
            foreach (var item in user2)
            {
                Console.WriteLine(item.Trim());
            }
            foreach (var item in user3)
            {
                Console.WriteLine(item.Trim());
            }
            foreach (var item in user4)
            {
                Console.WriteLine(item.Trim());
            }
            foreach (var item in user5)
            {
                Console.WriteLine(item.Trim());
            }


            //foreach (var item in allusers)
            //{
            //    Console.WriteLine(item.Email);
            //}
            //Console.WriteLine();
            //foreach (var item in allruns)
            //{
            //    Console.WriteLine(item.Time);
            //}
            //Console.WriteLine();
            //foreach (var item in allpass)
            //{
            //    Console.WriteLine(item.TotallySecuredVeryHashedPassword);
            //}





        }
    }
}
