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

    public class Repo_User : AbRepo<UserInformation>, IUserRepository
    {
        xDbContext ctx;
        public Repo_User(xDbContext context) : base(context)
        {
            this.ctx = context;
        }

        //CRUD Methods

        public void Create(string json)
        {
            UserInformation jUser = JsonConvert.DeserializeObject<UserInformation>(json);

            if (JsonConvert.DeserializeObject<UserInformation>(json).Full_Name== null)
            {
                throw new MissingNameException();
            }
            else if (JsonConvert.DeserializeObject<UserInformation>(json).Email == null)
            {
                throw new MissingEmailException();
            }

            ctx.Users.Attach(jUser);
            ctx.SaveChanges();
            Console.WriteLine("User added!");
      
        }
        public IQueryable<UserInformation> Read(int userID)
        {

            var us = from x in ctx.Users
                     where x.UserID.Equals(userID)
                     select x;

            IQueryable<UserInformation> ri = us.AsQueryable().Select(x => x);

            Console.WriteLine("User read!");

            return ri;
        }
        public IQueryable<UserInformation> ReadAll()
        {
            var us = from x in ctx.Users
                     select x;

            IQueryable<UserInformation> list = us.AsQueryable().Select(x => x);

            Console.WriteLine("All users read!");

            return list;
        }
        public void Update(string json, int userID)
        {
            UserInformation jUser = JsonConvert.DeserializeObject<UserInformation>(json);

            if (JsonConvert.DeserializeObject<UserInformation>(json).Full_Name == null)
            {
                throw new MissingNameException();
            }
            else if (JsonConvert.DeserializeObject<UserInformation>(json).Email == null)
            {
                throw new MissingEmailException();
            }
            
            UserInformation oldUser = ctx.Users
                .First(x => x.UserID.Equals(userID));

            ctx.Users.Remove(oldUser);

            jUser.runInfo = oldUser.runInfo;
            jUser.UserID = oldUser.UserID;

            ctx.Users.Add(jUser);
            ctx.SaveChanges();

            Console.WriteLine("User updated!");
        }
        public void Delete(int userID)
        {

            var us = from x in ctx.Users
                     select x;

            foreach (var item in us)
            {
                if (item.UserID.Equals(userID))
                {
                    ctx.Remove(item);
                }
            }
            ctx.SaveChanges();
            Console.WriteLine("User deleted!");
        }

        public void ReadRunsOfUsers()
        {
            Console.WriteLine("Enter userId: ");
            int id = int.Parse(Console.ReadLine());

            var us = from x in ctx.Runs
                     where x.UserID.Equals(id)
                     select x;

            foreach (var item in us)
            {
                Console.WriteLine(item.ToString());
            }

            //var se = from x in CTX.Users
            //         where x.UserID.Equals(id)
            //         select x;

            //List<UserInformation> selist = se.ToList();

            //foreach (var item in se)
            //{
            //    Console.WriteLine(item);
            //}

        }
    }
}
