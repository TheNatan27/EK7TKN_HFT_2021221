using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.IO;

namespace EK7TKN_HFT_2021221
{
    class Program
    {
        static void Main(string[] args)
        {

            #region probably should delete this later

            ////Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nátán\source\repos\TheNatan27\EK7TKN_HFT_2021221\EK7TKN_HFT_2021221.Data\Database1.mdf;Integrated Security=True


            //Console.WriteLine("Hello World CLIENT!");

            //UserInformationContext use = new UserInformationContext();

            //use.Users.Add(new UserInformation() { UserID = 05, Weight = 55 });
            //use.Users.Add(new UserInformation() { UserID = 02, Weight = 55 });
            //use.Users.Add(new UserInformation() { UserID = 03, Weight = 79 });
            //use.Users.Add(new UserInformation() { UserID = 04, Weight = 87 });

            //use.SaveChanges();


            //PasswordSecurityContext pass = new PasswordSecurityContext();
            //pass.Passwords.Add(new PasswordSecurity() { UserID = 01, TotallySecureVeryHashedPassword = "1234" });
            //pass.Passwords.Add(new PasswordSecurity() { UserID = 02, TotallySecureVeryHashedPassword = "1234" });
            //pass.Passwords.Add(new PasswordSecurity() { UserID = 03, TotallySecureVeryHashedPassword = "1234" });
            //pass.Passwords.Add(new PasswordSecurity() { UserID = 04, TotallySecureVeryHashedPassword = "1234" });

            //pass.SaveChanges();

            //RunInformationContext run = new RunInformationContext();
            //run.Runs.Add(new RunInformation() { UserID = 01, Distance = 12.4, Time = "01:04:42" });
            //run.Runs.Add(new RunInformation() { UserID = 02, Distance = 6.5, Time = "00:32:12" });
            //run.Runs.Add(new RunInformation() { UserID = 03, Distance = 3.0, Time = "00:14:00" });
            //run.Runs.Add(new RunInformation() { UserID = 04, Distance = 22, Time = "03:22:02" });

            //run.SaveChanges();
            #endregion

            
            xDbContext context = new xDbContext();
            Repo_User testUser = new Repo_User(context);
            Repo_Run testRun = new Repo_Run(context);
            Repo_Password testPass = new Repo_Password(context);

            Logic_Run loRun = new Logic_Run(testUser, testPass, testRun);

            Logic_Password loPass = new Logic_Password(testUser, testPass, testRun);


            Logic_User loUser = new Logic_User(testUser, testPass, testRun);

            loUser.Create("testUser3.txt");



            //testUser.GetAllUserIDs();
            //testUser.GetChonkers();
            
            //testUser.UpdateWeight();
            //testUser.GetChonkers();
            //testUser.AddUser();
            //testUser.GetAllUserIDs();
            //testUser.GetSmurfs();
            //testUser.GetRuns();


            //testUser.Delete();
            //testUser.ReadAll();
            //testUser.ReadRunsOfUsers();

            //testRun.ReadAllRuns();
            //testRun.DeleteRun();
            //testRun.UpdateRun();
            //testRun.CreateRun();
            //testRun.ReadAllRuns();
            //testRun.ReadRun();
            


        }
    }
}
