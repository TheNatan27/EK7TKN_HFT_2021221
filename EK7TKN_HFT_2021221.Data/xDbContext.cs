using EK7TKN_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EK7TKN_HFT_2021221.Data
{
    public class xDbContext : DbContext
    {
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True

        public virtual DbSet<RunInformation> Runs { get; set; }
        public virtual DbSet<PasswordSecurity> Passwords { get; set; }
        public virtual DbSet<UserInformation> Users { get; set; }

        public xDbContext(DbContextOptions<xDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public xDbContext() 
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                   

                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var listau = new List<UserInformation>()
            {

            new UserInformation() { UserID = 01, Weight = 26 },
            new UserInformation() { UserID = 02, Weight = 80 },
            new UserInformation() { UserID = 03, Weight = 25 },
            new UserInformation() { UserID = 04, Weight = 12 },
            new UserInformation() { UserID = 05, Weight = 47 },
            new UserInformation() { UserID = 06, Weight = 28 },
            new UserInformation() { UserID = 07, Weight = 73 },
            new UserInformation() { UserID = 08, Weight = 46 },
            new UserInformation() { UserID = 09, Weight = 49 },
            new UserInformation() { UserID = 10, Weight = 69 },
            new UserInformation() { UserID = 11, Weight = 97 },
            new UserInformation() { UserID = 12, Weight = 63 },
            new UserInformation() { UserID = 13, Weight = 45 },
            new UserInformation() { UserID = 14, Weight = 06 },
            new UserInformation() { UserID = 15, Weight = 91 },
            new UserInformation() { UserID = 16, Weight = 45 },
            new UserInformation() { UserID = 17, Weight = 47 },
            new UserInformation() { UserID = 18, Weight = 64 },
            new UserInformation() { UserID = 19, Weight = 89 },
            new UserInformation() { UserID = 20, Weight = 20 },
            new UserInformation() { UserID = 22, Weight = 36 },
            new UserInformation() { UserID = 23, Weight = 78 },
            new UserInformation() { UserID = 24, Weight = 07 },
            new UserInformation() { UserID = 25, Weight = 24 },
            new UserInformation() { UserID = 26, Weight = 57 },
            new UserInformation() { UserID = 27, Weight = 29 },
            new UserInformation() { UserID = 28, Weight = 73 },
            new UserInformation() { UserID = 29, Weight = 94 },
            new UserInformation() { UserID = 30, Weight = 58 },
            new UserInformation() { UserID = 31, Weight = 96 },
            new UserInformation() { UserID = 32, Weight = 35 },
            new UserInformation() { UserID = 33, Weight = 08 },
            new UserInformation() { UserID = 34, Weight = 73 },
            new UserInformation() { UserID = 35, Weight = 95 },
            new UserInformation() { UserID = 36, Weight = 47 },
            new UserInformation() { UserID = 37, Weight = 51 },
            new UserInformation() { UserID = 38, Weight = 05 },
            new UserInformation() { UserID = 39, Weight = 71 },
            new UserInformation() { UserID = 40, Weight = 69 },
            new UserInformation() { UserID = 41, Weight = 95 },
            new UserInformation() { UserID = 42, Weight = 00 },
            new UserInformation() { UserID = 43, Weight = 95 },
            new UserInformation() { UserID = 44, Weight = 57 },
            new UserInformation() { UserID = 45, Weight = 17 },
            new UserInformation() { UserID = 46, Weight = 79 },
            new UserInformation() { UserID = 47, Weight = 83 },
            new UserInformation() { UserID = 48, Weight = 56 },
            new UserInformation() { UserID = 49, Weight = 54 },
            new UserInformation() { UserID = 50, Weight = 30 },
            new UserInformation() { UserID = 51, Weight = 19 }
        };
            PasswordSecurity pass1 = new PasswordSecurity() { PasswordID = 01, UserID = 01, TotallySecureVeryHashedPassword = "pass" };
            PasswordSecurity pass2 = new PasswordSecurity() { PasswordID = 02, UserID = 02, TotallySecureVeryHashedPassword = "pass" };
            PasswordSecurity pass3 = new PasswordSecurity() { PasswordID = 03, UserID = 03, TotallySecureVeryHashedPassword = "pass" };
            PasswordSecurity pass4 = new PasswordSecurity() { PasswordID = 04, UserID = 04, TotallySecureVeryHashedPassword = "pass" };

            RunInformation run1 = new RunInformation() { UserID = 01, Distance = 12.3, RunID = 01, Time = "01:32:03" };
            RunInformation run2 = new RunInformation() { UserID = 02, Distance = 12.3, RunID = 02, Time = "01:32:03" };
            RunInformation run3 = new RunInformation() { UserID = 03, Distance = 12.3, RunID = 03, Time = "01:32:03" };
            RunInformation run4 = new RunInformation() { UserID = 04, Distance = 12.3, RunID = 04, Time = "01:32:03" };

            modelBuilder.Entity<RunInformation>().HasData(run1, run2, run3, run4);
            modelBuilder.Entity<PasswordSecurity>().HasData(pass1, pass2, pass3, pass4);
            modelBuilder.Entity<UserInformation>().HasData(listau);



            #region commented outmight needed later


            //use.Users.Add(new UserInformation() { UserID = 01, Weight = 77 });
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



        }

    }
}
