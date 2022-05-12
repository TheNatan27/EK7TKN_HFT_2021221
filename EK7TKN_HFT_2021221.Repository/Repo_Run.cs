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
    public class NegativeDistanceException : Exception
    {
        public NegativeDistanceException()
        {
            Console.WriteLine("Error: No name specified");
        }
    }
    public class MissingLocationException : Exception
    {
        public MissingLocationException()
        {
            Console.WriteLine("Error: No location provided");
        }
    }
    public class WrongUserIDException : Exception
    {
        public WrongUserIDException()
        {
            Console.WriteLine("Error: Wrong user id provided");
        }
    }
    public class Repo_Run : AbRepo<RunInformation>, IRepository<RunInformation>
    {
        xDbContext ctx;
        public Repo_Run(xDbContext context) : base(context)
        {
            this.ctx = context;
        }

        //CRUD Methods

        public override RunInformation Read(int id)
        {
            return ctx.Runs.FirstOrDefault(x => x.RunID == id);
        }
        public override void Update(RunInformation item)
        {
            RunInformation oldRun = ctx.Runs
              .First(x => x.RunID.Equals(item.RunID));

            ctx.Runs.Remove(oldRun);

            item.userInfo = oldRun.userInfo;
            item.RunID = oldRun.RunID;
            item.UserID = oldRun.UserID;
            ctx.Runs.Add(item);
            ctx.SaveChanges();
        }

    }

}
