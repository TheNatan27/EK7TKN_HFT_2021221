using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class Repo_Password : AbRepo<Repo_Password>
    {
        xDbContext ctx;
        public Repo_Password(xDbContext context) : base(context)
        {
            this.ctx = context;
        }

        //CRUD Methods
        public void CreateRun()
        {
            Console.WriteLine("Enter Password:");
            string pass = (Console.ReadLine());

            PasswordSecurity newPass = new PasswordSecurity()
            {
                TotallySecureVeryHashedPassword = pass
            };

            ctx.Passwords.Attach(newPass);
            ctx.SaveChanges();

        }
        public void ReadRun()
        {
            Console.WriteLine("Enter PasswordID: ");
            int id = int.Parse(Console.ReadLine());
            var us = from x in ctx.Passwords
                     where x.UserId.Equals(id)
                     select x;
            foreach (var item in us)
            {
                Console.WriteLine(item.ToString());
            }

        }
        public void UpdateRun()
        {
            bool menu = true;

            Console.WriteLine("Enter Id of password you would like to update: ");
            int id = int.Parse(Console.ReadLine());

            var use = from x in ctx.Passwords
                      where x.UserId.Equals(id)
                      select x;

            foreach (var item in use)
            {
                Console.WriteLine("Old password: " + item.TotallySecureVeryHashedPassword);
            }
            Console.WriteLine("Enter new password:");
            string change = Console.ReadLine();

            foreach (var item in use)
            {
                item.TotallySecureVeryHashedPassword = change;
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
            Console.Clear();


            
        }
        public void DeleteRun()
        {
            Console.WriteLine("Enter Id of password you would like to delete:");
            int id = int.Parse(Console.ReadLine());

            var us = from x in ctx.Passwords
                     select x;

            foreach (var item in us)
            {
                if (item.UserId.Equals(id))
                {
                    ctx.Remove(item);
                }
            }
            ctx.SaveChanges();

        }
        public IQueryable<PasswordSecurity> ReadAllRuns()
        {
            var us = from x in ctx.Passwords
                     select x;

            IQueryable<PasswordSecurity> list = us.AsQueryable().Select(x => x);

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            return list;
        }
    }
}
