using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Models
{
    [Table("Passwords")]
    public class PasswordSecurity
    {
        [ForeignKey(nameof(UserInformation))]
        public int UserID { get; set; }
        [Key]
        public int PasswordID { get; set; }
        public string TotallySecureVeryHashedPassword { get; set; }


    }

    //public class PasswordSecurityContext : DbContext
    //{
    //    public virtual DbSet<PasswordSecurity> Passwords { get; set; }

    //    public PasswordSecurityContext()
    //    {
    //        this.Database.EnsureCreated();
    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        if (!optionsBuilder.IsConfigured)
    //        {
    //            optionsBuilder
    //                .UseLazyLoadingProxies()
    //                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");

    //        }
    //    }


    //}
}
