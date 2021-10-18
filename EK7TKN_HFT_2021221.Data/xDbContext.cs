using EK7TKN_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;

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
            Console.WriteLine("Hello World DATABASE!");

            modelBuilder.Entity<UserInformation>(entity =>
            {
                entity
                .HasKey(Users => Users.UserID)
                .ok
                .OnDelete(DeleteBehavior.ClientSetNull);


            });


            //UserInformationContext use = new UserInformationContext();

            //UserInformation user1 = new UserInformation() { UserID = 01, Weight = 77 };
            //UserInformation user2 = new UserInformation() { UserID = 02, Weight = 77 };
            //UserInformation user3 = new UserInformation() { UserID = 03, Weight = 77 };
            //UserInformation user4 = new UserInformation() { UserID = 04, Weight = 77 };

            //PasswordSecurity pass1 = new PasswordSecurity() { PasswordID = 01, UserID = 01, TotallySecureVeryHashedPassword = "pass" };
            //PasswordSecurity pass2 = new PasswordSecurity() { PasswordID = 02, UserID = 02, TotallySecureVeryHashedPassword = "pass" };
            //PasswordSecurity pass3 = new PasswordSecurity() { PasswordID = 03, UserID = 03, TotallySecureVeryHashedPassword = "pass" };
            //PasswordSecurity pass4 = new PasswordSecurity() { PasswordID = 04, UserID = 04, TotallySecureVeryHashedPassword = "pass" };

            //RunInformation run1 = new RunInformation() { UserID = 01, Distance = 12.3, RunID = 01, Time = "01:32:03" };
            //RunInformation run2 = new RunInformation() { UserID = 02, Distance = 12.3, RunID = 01, Time = "01:32:03" };
            //RunInformation run3 = new RunInformation() { UserID = 03, Distance = 12.3, RunID = 01, Time = "01:32:03" };
            //RunInformation run4 = new RunInformation() { UserID = 04, Distance = 12.3, RunID = 01, Time = "01:32:03" };

            

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
