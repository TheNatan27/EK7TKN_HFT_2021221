using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class MissingDistanceException : Exception
    {
        public MissingDistanceException()
        {
            Console.WriteLine("Error: No name specified");
        }
    }
    public class CompetitionNotSpecifiedException : Exception
    {
        public CompetitionNotSpecifiedException()
        {
            Console.WriteLine("Error: No email provided");
        }
    }
    public class MissingLocationException : Exception
    {
        public MissingLocationException()
        {
            Console.WriteLine("Error: No age provided");
        }
    }
    public class MissingUserIDException : Exception
    {
        public MissingUserIDException()
        {
            Console.WriteLine("Error: Premium status is not specified");
        }
    }
    public class Repo_Run : AbRepo<RunInformation>, IRunRepository
    {
        xDbContext ctx;
        public Repo_Run(xDbContext context) : base(context)
        {
            this.ctx = context;
        }

        //CRUD Methods

        public void Create(string filename)
        {
            string[] lines = File.ReadAllLines(filename);


            if (lines[0] == "")
            {
                throw new MissingDistanceException();
            }
            else if (lines[1] == "")
            {
                throw new CompetitionNotSpecifiedException();
            }
            else if (lines[2] == "")
            {
                throw new MissingLocationException();
            }
            else if (lines[4] == "")
            {
                throw new MissingUserIDException();
            }

            RunInformation newRun = new RunInformation()
            {
                Distance = int.Parse(lines[0]),
                IsCompetition=bool.Parse(lines[1]),
                Location=lines[2],
                Time=lines[3],
                UserID=int.Parse(lines[4])
            };


            ctx.Runs.Attach(newRun);
            ctx.SaveChanges();

        }
        public IQueryable<RunInformation> Read(int runID)
        {
            var us = from x in ctx.Runs
                     where x.RunID.Equals(runID)
                     select x;
            IQueryable<RunInformation> ri = us.AsQueryable().Select(x => x);

            return ri;
            
        }
        public void Update(string filenameU, int runID)
        {
            string[] lines = File.ReadAllLines(filenameU);

            if (lines[0] == "")
            {
                throw new MissingDistanceException();
            }
            else if (lines[1] == "")
            {
                throw new CompetitionNotSpecifiedException();
            }
            else if (lines[2] == "")
            {
                throw new MissingLocationException();
            }
            else if (lines[4] == "")
            {
                throw new MissingUserIDException();
            }

            RunInformation oldRun = ctx.Runs
                .First(x => x.RunID.Equals(runID));

            ctx.Runs.Remove(oldRun);

            RunInformation newRun = new RunInformation()
            {
                RunID = oldRun.RunID,
                userInfo = oldRun.userInfo,
                Distance = double.Parse(lines[0]),
                IsCompetition = bool.Parse(lines[1]),
                Location = lines[2].ToString(),
                Time = lines[3].ToString(),
                UserID = int.Parse(lines[4])
            };

            ctx.Add(newRun);
            ctx.SaveChanges();
            Console.WriteLine();
        }
        public void Delete(int runID)
        {

            var us = from x in ctx.Runs
                     select x;

            foreach (var item in us)
            {
                if (item.RunID.Equals(runID))
                {
                    ctx.Remove(item);
                }
            }
            ctx.SaveChanges();

        }
        public IQueryable<RunInformation> ReadAll()
        {
            var us = from x in ctx.Runs
                     select x;

            IQueryable<RunInformation> list = us.AsQueryable().Select(x => x);

            return list;
        }

    }

    
}
