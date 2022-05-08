using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class MissingNameException : Exception
    {
        public MissingNameException()
        {
            Console.WriteLine("Error: No name specified");
        }
    }
    public class MissingEmailException : Exception
    {
        public MissingEmailException()
        {
            Console.WriteLine("Error: No email provided");
        }
    }

    public class Repo_User : AbRepo<UserInformation>, IRepository<UserInformation>
    {
        xDbContext ctx;
        public Repo_User(xDbContext context) : base(context)
        {
            this.ctx = context;
        }

        //CRUD Methods

        public override UserInformation Read(int id)
        {
            return ctx.Users.FirstOrDefault(x => x.UserID == id);
        }
        public override void Update(UserInformation item)
        {
            var old = Read(item.UserID);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }

    }
}
