using ConsoleTools;
using EK7TKN_HFT_2021221.Client;
using EK7TKN_HFT_2021221.Models;
using Newtonsoft.Json;
using System;

namespace EK7TKN_HFT_2021221
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //Rest service setup

            System.Threading.Thread.Sleep(2500);

            RestService rest = new RestService("http://localhost:5000");


            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            UI uiRest = new UI(rest);

            #region menu

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

            #endregion

            MainMenu.Show();
        }
   
    }
}
