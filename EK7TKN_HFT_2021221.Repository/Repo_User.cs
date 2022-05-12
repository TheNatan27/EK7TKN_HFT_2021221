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
            return ctx.Users.FirstOrDefault(x => x.userID == id);
        }
        public override void Update(UserInformation item)
        {
            UserInformation oldUser = ctx.Users
              .First(x => x.userID.Equals(item.userID));

            ctx.Users.Remove(oldUser);

            item.runInfo = oldUser.runInfo;
            item
                .userID = oldUser.userID;
            ctx.Users.Add(item);
            ctx.SaveChanges();
        }

    }
}
