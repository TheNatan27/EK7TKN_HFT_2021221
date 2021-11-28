using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
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
    public class MissingAgeException : Exception
    {
        public MissingAgeException()
        {
            Console.WriteLine("Error: No age provided");
        }
    }
    public class PremiumStatusNotSpecifiedException : Exception
    {
        public PremiumStatusNotSpecifiedException()
        {
            Console.WriteLine("Error: Premium status is not specified");
        }
    }
    public class Repo_User : AbRepo<UserInformation>, IUserRepository
    {
        xDbContext CTX;
        public Repo_User(xDbContext context) : base(context)
        {
            this.CTX = context;
        }

        //CRUD Methods

        public void Create(string filename)
        {
            string[] lines = File.ReadAllLines(filename);


            if (lines[0] == "")
            {
                throw new MissingNameException();
            }
            else if (lines[1] == "")
            {
                throw new MissingEmailException();
            }
            else if (lines[2] == "")
            {
                throw new MissingAgeException();
            }
            else if (lines[5] == "")
            {
                throw new PremiumStatusNotSpecifiedException();
            }

            UserInformation newUser = new UserInformation(){
                Full_Name = lines[0],
                Email = lines[1],
                Age = int.Parse(lines[2]), 
                Height = int.Parse(lines[3]),
                Weight = int.Parse(lines[4]),
                Premium = bool.Parse(lines[5]) };

            Console.WriteLine(newUser.ToString());

            CTX.Users.Attach(newUser);
            CTX.SaveChanges();

            Console.WriteLine("User added!");
      
        }

        public IQueryable<UserInformation> Read(int userID)
        {

            var us = from x in CTX.Users
                     where x.UserID.Equals(userID)
                     select x;

            IQueryable<UserInformation> ri = us.AsQueryable().Select(x => x);

            return ri; 

        }
        public IQueryable<UserInformation> ReadAll()
        {
            var us = from x in CTX.Users
                     select x;

            IQueryable<UserInformation> list = us.AsQueryable().Select(x => x);

            return list;
        }
        public void Update(string filenameU, int userID)
        {
            string[] lines = File.ReadAllLines(filenameU);


            if (lines[0] == "")
            {
                throw new MissingNameException();
            }
            else if (lines[1] == "")
            {
                throw new MissingEmailException();
            }
            else if (lines[2] == "")
            {
                throw new MissingAgeException();
            }
            else if (lines[5] == "")
            {
                throw new PremiumStatusNotSpecifiedException();
            }

            UserInformation oldUser = CTX.Users
                .First(x => x.UserID.Equals(userID));

            CTX.Users.Remove(oldUser);

            UserInformation newUser = new UserInformation()
            {
                runInfo = oldUser.runInfo,
                UserID = oldUser.UserID,
                Full_Name = lines[0],
                Email = lines[1],
                Age = int.Parse(lines[2]),
                Height = int.Parse(lines[3]),
                Weight = int.Parse(lines[4]),
                Premium = bool.Parse(lines[5])
            };

            CTX.Users.Add(newUser);

            oldUser = newUser;
            CTX.SaveChanges();


        }
        public void Delete(int userID)
        {

            var us = from x in CTX.Users
                     where x.UserID.Equals(userID)
                     select x;

            CTX.Remove(us);
            CTX.SaveChanges();
        }

        public void ReadRunsOfUsers()
        {
            Console.WriteLine("Enter userId: ");
            int id = int.Parse(Console.ReadLine());

            var us = from x in CTX.Runs
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
