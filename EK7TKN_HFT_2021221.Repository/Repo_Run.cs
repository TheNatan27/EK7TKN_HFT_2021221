using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class Repo_Run : AbRepo<RunInformation>
    {
        xDbContext ctx;
        public Repo_Run(xDbContext context) : base(context)
        {
            this.ctx = context;
        }

        //CRUD Methos

        public void CreateRun()
        {
            Console.WriteLine("Enter Distance:");
            double distance = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Time: ");
            string time = Console.ReadLine();
            Console.WriteLine("Enter UserID: ");
            int uid = int.Parse(Console.ReadLine());

            RunInformation newRun = new RunInformation()
            {
                Distance = distance,
                Time = time,
                UserID = uid
            };

            ctx.Runs.Attach(newRun);
            ctx.SaveChanges();

        }
        public void ReadRun()
        {
            Console.WriteLine("Enter RunId: ");
            int id = int.Parse(Console.ReadLine());
            var us = from x in ctx.Runs
                     where x.RunID.Equals(id)
                     select x;
            foreach (var item in us)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
        public void UpdateRun()
        {
            bool menu = true;

            Console.WriteLine("Enter Id of user you would like to update: ");
            int id = int.Parse(Console.ReadLine());

            var use = from x in ctx.Runs
                      where x.RunID.Equals(id)
                      select x;



            while (menu)
            {
                Console.WriteLine("What would you like to update?");
                Console.WriteLine("1: Distance");
                Console.WriteLine("2: Time");
                Console.WriteLine("3: Exit");


                int input = int.Parse(Console.ReadLine());
                Console.Clear();




                switch (input)
                {
                    case 1:
                        {
                            foreach (var item in use)
                            {
                                Console.WriteLine("Old distance: " + item.Distance);
                            }
                            Console.WriteLine("Enter new distance:");
                            double change = double.Parse(Console.ReadLine());

                            foreach (var item in use)
                            {
                                item.Distance = change;
                            }
                            Console.WriteLine("Done!");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            foreach (var item in use)
                            {
                                Console.WriteLine("Old time: " + item.Time);
                            }
                            Console.WriteLine("Enter new time:");
                            string change = Console.ReadLine();

                            foreach (var item in use)
                            {
                                item.Time = change;
                            }
                            Console.WriteLine("Done!");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            menu = false;
                            break;
                        }
                }
            }

            try
            {
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void DeleteRun()
        {
            Console.WriteLine("Enter Id of run you would like to delete:");
            int id = int.Parse(Console.ReadLine());

            var us = from x in ctx.Runs
                     select x;

            foreach (var item in us)
            {
                if (item.RunID.Equals(id))
                {
                    ctx.Remove(item);
                }
            }
            ctx.SaveChanges();

        }
        public IQueryable<RunInformation> ReadAllRuns()
        {
            var us = from x in ctx.Runs
                     select x;

            IQueryable<RunInformation> list = us.AsQueryable().Select(x => x);

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            return list;
        }

    }

    
}
