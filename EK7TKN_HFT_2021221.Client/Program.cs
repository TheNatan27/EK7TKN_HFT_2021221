using ConsoleTools;
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
            #region testing, to be ignored or deleted 

            //xDbContext context = new xDbContext();
            //Repo_Run run = new Repo_Run(context);
            //Repo_User user = new Repo_User(context);
            //Repo_Password password = new Repo_Password(context);

            //Logic_Run rlogic = new Logic_Run(user, password, run);
            //Logic_User ulogic = new Logic_User(user, password, run);
            //Logic_Password plogic = new Logic_Password(user, password, run);

            //Console.WriteLine("/////");

            

            //var sl = ulogic.ReadAll();

            //foreach (var item in sl)
            //{
            //    Console.WriteLine(item.ToString());
            //}

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



            //Rest service setup

            System.Threading.Thread.Sleep(2500);

            RestService rest = new RestService("http://localhost:5000");

            //var hj = rest.Get<UserInformation>(2, "user/read");
            //Console.WriteLine(hj.ToString());

            //List<UserInformation> allusers = rest.GetAll<UserInformation>("user");
            //List<RunInformation> allruns = rest.GetAll<RunInformation>("run");
            //List<PasswordSecurity> allpass = rest.GetAll<PasswordSecurity>("password");

            #region post, update, delete  

            //////////////////////

            PasswordSecurity jPass = new PasswordSecurity()
            {
                TotallySecuredVeryHashedPassword = "jsonpassword",
                RecoverPhoneNumber = "012345678",
                UserId = 222
            };

            string jsonPass = JsonConvert.SerializeObject(jPass);

            //rest.Post<string>(jsonPass, "pass/post");
            //Console.WriteLine("posted");

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

            //rest.Post<string>(jsonRun, "run/post");
            //Console.WriteLine("posted");

            //////////////////////////
            ////////////////////////////
            ////////////////////////////


            PasswordSecurity uPass = new PasswordSecurity()
            {
                TotallySecuredVeryHashedPassword = "updated",
                RecoverPhoneNumber = "updated",
                UserId = 1
            };

            string ujsonPass = JsonConvert.SerializeObject(uPass);

            //rest.Put<string>(ujsonPass, "pass/put/1");
            //Console.WriteLine("updated");

            #endregion


            #endregion

            #region menu


            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            UI uiRest = new UI(rest);

            var UserMenu = new ConsoleMenu(args, level: 1)
                .Add("Read all users", () => uiRest.AllUsers())
                .Add("Read a user", () => uiRest.ReadAUser())
                .Add("Add a user", () => uiRest.CreateAUser())
                .Add("Update a user", () => uiRest.UpdateAUser())
                .Add("Delete a user", () => uiRest.DeleteAUser())
                .Add("Read runs of users", () => uiRest.ReadRunsOfUser())
                .Add("Get email of weak password users", () => uiRest.GetEmailOfWeakPasswordUsers())
                .Add("Get competitors email addresses", () => uiRest.GetCompetitorsEmailAddress())
                .Add("Get american users names", () => uiRest.GetAmericanUsersNames())
                .Add("Get long distance competitors names", () => uiRest.GetLongDistanceCompetitorsNames())
                .Add("Get name of long distance old runners", () => uiRest.GetNameOfLongDistanceOldRunners())
                .Add("Close", ConsoleMenu.Close)
                               .Configure(config =>
                               {
                                   config.Selector = "--> ";
                                   config.EnableFilter = true;
                                   config.Title = "User menu";
                                   config.EnableBreadcrumb = true;
                                   config.ItemBackgroundColor = ConsoleColor.White;
                                   config.SelectedItemBackgroundColor = ConsoleColor.DarkGreen;
                                   config.ItemForegroundColor = ConsoleColor.DarkGreen;
                                   config.SelectedItemForegroundColor = ConsoleColor.Gray;

                               });

            var RunMenu = new ConsoleMenu(args, level: 1)
    .Add("Read all runs", () => uiRest.AllRuns())
    .Add("Read a run", () => uiRest.ReadARun())
    .Add("Add a run", () => uiRest.CreateARun())
    .Add("Update a run", () => uiRest.UpdateARun())
    .Add("Delete a run", () => uiRest.DeleteARun())
    .Add("Get run id of premium users", () => uiRest.GetRunIDOfPremiumUsers())
    .Add("Get time of premium competitors", () => uiRest.GetTimeOfPremiumCompetitors())
    .Add("Get run id of long distance junior runners", () => uiRest.GetRunIDOfLongDistanceJuniorRunners())
    .Add("Get location of chonkers", () => uiRest.GetLocationOfChonkers())
    .Add("Get location of junior premium users", () => uiRest.GetLocationOfJuniorPremiumUsers())
    .Add("Close", ConsoleMenu.Close)
                   .Configure(config =>
                   {
                       config.Selector = "--> ";
                       config.EnableFilter = true;
                       config.Title = "Run menu";
                       config.EnableBreadcrumb = true;
                       config.ItemBackgroundColor = ConsoleColor.White;
                       config.SelectedItemBackgroundColor = ConsoleColor.DarkGreen;
                       config.ItemForegroundColor = ConsoleColor.DarkGreen;
                       config.SelectedItemForegroundColor = ConsoleColor.Gray;

                   });

            var PasswordMenu = new ConsoleMenu(args, level: 1)
.Add("Read all runs", () => uiRest.AllPasswords())
.Add("Read a run", () => uiRest.ReadAPassword())
.Add("Add a run", () => uiRest.CreateAPassword())
.Add("Update a run", () => uiRest.UpdateAPassword())
.Add("Delete a run", () => uiRest.DeleteAPassword())
.Add("Get old people's pass id", () => uiRest.GetOldPeoplesPassID())
.Add("Get opd people's pass id with weak passwords", () => uiRest.GetOldPeoplesPassIDWithWeakPassword())
.Add("Get pass id of premium users", () => uiRest.GetPassIDOfPremiumUsers())
.Add("Get phone number of premium users", () => uiRest.GetPhoneNumberOfPremiumUsers())
.Add("Get phone number of competitors", () => uiRest.GetPhoneNumberOfCompetitors())
.Add("Close", ConsoleMenu.Close)
       .Configure(config =>
       {
           config.Selector = "--> ";
           config.EnableFilter = true;
           config.Title = "Password menu";
           config.EnableBreadcrumb = true;
           config.ItemBackgroundColor = ConsoleColor.White;
           config.SelectedItemBackgroundColor = ConsoleColor.DarkGreen;
           config.ItemForegroundColor = ConsoleColor.DarkGreen;
           config.SelectedItemForegroundColor = ConsoleColor.Gray;

       });

            var MainMenu = new ConsoleMenu(args, level: 0)
                .Add("User Menu", () => UserMenu.Show())
                .Add("Run Menu", () => RunMenu.Show())
                .Add("Password Menu", () => PasswordMenu.Show())
                .Add("Exit", () => Environment.Exit(0))
                .Configure(config =>
                {
                    config.Selector = "--> ";
                    config.EnableFilter = true;
                    config.Title = "Main menu";
                    config.EnableBreadcrumb = true;
                    config.ItemBackgroundColor = ConsoleColor.White;
                    config.SelectedItemBackgroundColor = ConsoleColor.DarkGreen;
                    config.ItemForegroundColor = ConsoleColor.DarkGreen;
                    config.SelectedItemForegroundColor = ConsoleColor.Gray;

                });



            MainMenu.Show();


            #endregion

        }



 //blasdbflajsdhbflajshdbflajshdbf
 //bug fux 001
 
        //bug fix 002

        //static bool UsersMenu()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Choose a query:");
        //    Console.WriteLine("1) Get all users");
        //    Console.WriteLine("2) Get one user");
        //    Console.WriteLine("3) Create a user");
        //    Console.WriteLine("4) Update a user");
        //    Console.WriteLine("5) Delete a user");
        //    Console.WriteLine("6) ReadRunsOfUser");
        //    Console.WriteLine("7) GetEmailOfWeakPasswordUsers");
        //    Console.WriteLine("8) GetCompetitorsEmailAddress");
        //    Console.WriteLine("9) GetAmericanUsersNames");
        //    Console.WriteLine("10) GetLongDistanceCompetitorsNames");
        //    Console.WriteLine("11) GetNameOfLongDistanceOldRunners");
        //    Console.WriteLine("12) Back");

        //    Console.Write("\r\nSelect an option: ");

        

   
    }
}
