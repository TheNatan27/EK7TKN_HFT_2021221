using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Models
{
    public class RunBetterAppContext : DbContext
    {
        public virtual DbSet<RunInformation> Runs { get; set; }
        public virtual DbSet<PasswordSecurity> Passwords { get; set; }
        public virtual DbSet<UserInformation> Users { get; set; }

        public RunBetterAppContext()
        {
            this.Database.EnsureCreated();
        }
        public RunBetterAppContext(DbContextOptions options) : base(options)
        {

        }

    }
}
