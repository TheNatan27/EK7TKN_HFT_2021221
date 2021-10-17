using EK7TKN_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EK7TKN_HFT_2021221.Data
{
    public class Class1 : DbContext
    {

        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("Hello World CLIENT!");

            UserInformationContext use = new UserInformationContext();

            use.Users.Add(new UserInformation() { UserID = 01, Weight = 77 });
            use.Users.Add(new UserInformation() { UserID = 02, Weight = 55 });
            use.Users.Add(new UserInformation() { UserID = 03, Weight = 79 });
            use.Users.Add(new UserInformation() { UserID = 04, Weight = 87 });

            use.SaveChanges();


            PasswordSecurityContext pass = new PasswordSecurityContext();
            pass.Passwords.Add(new PasswordSecurity() { UserID = 01, TotallySecureVeryHashedPassword = "1234" });
            pass.Passwords.Add(new PasswordSecurity() { UserID = 02, TotallySecureVeryHashedPassword = "1234" });
            pass.Passwords.Add(new PasswordSecurity() { UserID = 03, TotallySecureVeryHashedPassword = "1234" });
            pass.Passwords.Add(new PasswordSecurity() { UserID = 04, TotallySecureVeryHashedPassword = "1234" });

            pass.SaveChanges();

            RunInformationContext run = new RunInformationContext();
            run.Runs.Add(new RunInformation() { UserID = 01, Distance = 12.4, Time = "01:04:42" });
            run.Runs.Add(new RunInformation() { UserID = 02, Distance = 6.5, Time = "00:32:12" });
            run.Runs.Add(new RunInformation() { UserID = 03, Distance = 3.0, Time = "00:14:00" });
            run.Runs.Add(new RunInformation() { UserID = 04, Distance = 22, Time = "03:22:02" });

            run.SaveChanges();


        }

    }
}
