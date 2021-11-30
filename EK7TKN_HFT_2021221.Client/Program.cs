using EK7TKN_HFT_2021221.Client;
using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EK7TKN_HFT_2021221
{
    class Program
    {
        static void Main(string[] args)
        {
            #region testing, to be deleted 

            xDbContext context = new xDbContext();
            Repo_Run run = new Repo_Run(context);
            Repo_User user = new Repo_User(context);
            Repo_Password password = new Repo_Password(context);

            Logic_Run rlogic = new Logic_Run(user, password, run);
            Logic_User ulogic = new Logic_User(user, password, run);
            Logic_Password plogic = new Logic_Password(user, password, run);

           

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

            #region service

            System.Threading.Thread.Sleep(2500);

            RestService rest = new RestService("http://localhost:5000");

            List<UserInformation> allusers = rest.GetAll<UserInformation>("user");
            List<RunInformation> allruns = rest.GetAll<RunInformation>("run");
            List<PasswordSecurity> allpass = rest.GetAll<PasswordSecurity>("password");

            var se = rest.GetAll<UserInformation>("user/5");

            Console.WriteLine(se.ToString());

            //////////////////////
            
            PasswordSecurity jPass = new PasswordSecurity()
            {
                TotallySecuredVeryHashedPassword = "jsonpassword",
                RecoverPhoneNumber = "012345678",
                UserId = 222
            };

            string jsonPass = JsonConvert.SerializeObject(jPass);

            rest.Post<string>(jsonPass, "pass/put");
            Console.WriteLine("posted");

            Console.WriteLine(jsonPass);

            ///////////////////////////

            RunInformation jRun = new RunInformation()
            {
                Distance =222.2,
                IsCompetition =true,
                Location ="Utopia",
                Time ="55:66:77",
                UserID =1
            };

            string jsonRun = JsonConvert.SerializeObject(jRun);

            rest.Post<string>(jsonRun, "run/put");
            Console.WriteLine("posted");

            Console.WriteLine(jsonRun);

            //List<string> user1 = rest.GetAll<string>("user/GetEmailOfWeakPasswordUsers");
            //List<string> user2 = rest.GetAll<string>("user/GetCompetitorsEmailAddress");
            //List<string> user3 = rest.GetAll<string>("user/GetAmericanUsersNames");
            //List<string> user4 = rest.GetAll<string>("user/GetLongDistanceCompetitorsNames");
            //List<string> user5 = rest.GetAll<string>("user/GetNameOfLongDistanceOldRunners");

            //List<int> run1 = rest.GetAll<int>("run/GetRunIDOfPremiumUsers");
            //List<string> run2 = rest.GetAll<string>("run/GetTimeOfPremiumCompetitors");
            //List<int> run3 = rest.GetAll<int>("run/GetRunIDOfLongDistanceJuniorRunners");
            //List<string> run4 = rest.GetAll<string>("run/GetLocationOfChonkers");
            //List<string> run5 = rest.GetAll<string>("run/GetLocationOfJuniorPremiumUsers");

            //List<int> pass1 = rest.GetAll<int>("pass/GetOldPeoplesPassID");
            //List<int> pass2 = rest.GetAll<int>("pass/GetOldPeoplesPassIDWithWeakPassword");
            //List<int> pass3 = rest.GetAll<int>("pass/GetPassIDOfPremiumUsers");
            //List<string> pass4 = rest.GetAll<string>("pass/GetPhoneNumberOfPremiumUsers");
            //List<string> pass5 = rest.GetAll<string>("pass/GetPhoneNumberOfCompetitors");
            //List<string> pass6 = rest.GetAll<string>("pass/GetPasswordOfUserByName");

            #region writes to console

            //Console.WriteLine("GetOldPeoplesPassID");
            //foreach (var item in pass1)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("GetOldPeoplesPassIDWithWeakPassword");
            //foreach (var item in pass2)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("GetPassIDOfPremiumUsers");
            //foreach (var item in pass3)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("GetPhoneNumberOfPremiumUsers");
            //foreach (var item in pass4)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("GetPhoneNumberOfCompetitors");
            //foreach (var item in pass5)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("GetPasswordOfUserByName");
            //foreach (var item in pass6)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion
            #endregion

        }

    }
}
