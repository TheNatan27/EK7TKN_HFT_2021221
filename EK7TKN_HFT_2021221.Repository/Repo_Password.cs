using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class MissingPasswordException : Exception
    {
        public MissingPasswordException()
        {
            Console.WriteLine("Error: No name specified");
        }
    }
    public class MissingPhoneNumberException : Exception
    {
        public MissingPhoneNumberException()
        {
            Console.WriteLine("Error: No email provided");
        }
    }
    public class Repo_Password : AbRepo<PasswordSecurity>, IRepository<PasswordSecurity>
    {
        xDbContext ctx;
        public Repo_Password(xDbContext context) : base(context)
        {
            this.ctx = context;
        }

        //CRUD Methods

        public override PasswordSecurity Read(int id)
        {
            return ctx.Passwords.FirstOrDefault(x => x.PassId == id);
        }
        public override void Update(PasswordSecurity item)
        {
            PasswordSecurity oldPass = ctx.Passwords
              .First(x => x.PassId.Equals(item.PassId));

            ctx.Passwords.Remove(oldPass);

            item.userInformation = oldPass.userInformation;
            item.UserId = oldPass.UserId;
            item.PassId = oldPass.PassId;
            ctx.Passwords.Add(item);
            ctx.SaveChanges();
        }

    }
}
