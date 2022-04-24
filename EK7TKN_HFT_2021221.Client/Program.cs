using ConsoleTools;
using EK7TKN_HFT_2021221.Models;
using Newtonsoft.Json;
using System;

namespace EK7TKN_HFT_2021221.Client
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
                .Add("Read a user", () => uiRest.ReadAUser())        
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
    .Add("Read a run", () => uiRest.ReadARun())
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
.Add("Read a password", () => uiRest.ReadAPassword())
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
