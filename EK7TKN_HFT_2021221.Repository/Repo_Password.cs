using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
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
    public class Repo_Password : AbRepo<Repo_Password>, IPassRepository
    {
        xDbContext ctx;
        public Repo_Password(xDbContext context) : base(context)
        {
            this.ctx = context;
        }

        //CRUD Methods
        public void Create(string json)
        {
            PasswordSecurity jPass = JsonConvert.DeserializeObject<PasswordSecurity>(json);

            if (jPass.TotallySecuredVeryHashedPassword == "")
            {
                throw new MissingPasswordException();
            }
            else if (jPass.RecoverPhoneNumber.Equals(null))
            {
                throw new MissingPhoneNumberException();
            }
            else if (jPass.UserId.Equals(null))
            {
                throw new MissingUserIDException();
            }

            ctx.Passwords.Attach(jPass);
            ctx.SaveChanges();


            #region old method

            //line = line.Trim();

            //string[] lines1 = line.Split("-");
            //string[] lines = new string[lines1.Length];

            //for (int i = 0; i < lines1.Length; i++)
            //{
            //    lines[i] = lines1[i].Trim();
            //    lines[i] = lines[i].Trim();
            //    Console.WriteLine(lines[i]);
            //}

            //Console.WriteLine();

            //if (lines[0] == "")
            //{
            //    throw new MissingPasswordException();
            //}
            //else if (lines[1] == "")
            //{
            //    throw new MissingPhoneNumberException();
            //}
            //else if (lines[2] == "")
            //{
            //    throw new MissingUserIDException();
            //}

            //PasswordSecurity newPass = new PasswordSecurity()
            //{
            //    TotallySecuredVeryHashedPassword = lines[0],
            //    RecoverPhoneNumber = lines[1],
            //    UserId = int.Parse(lines[2])
            //};

            //ctx.Passwords.Attach(newPass);
            //ctx.SaveChanges();

            #endregion
        }
        public IQueryable<PasswordSecurity> Read(int userID)
        {

            var us = from x in ctx.Passwords
                     where x.UserId.Equals(userID)
                     select x;

            IQueryable<PasswordSecurity> ri = us.AsQueryable().Select(x => x);

            

            return ri;

        }
        public void Update(string filenameU, int passID)
        {

            string[] lines = File.ReadAllLines(filenameU);

            if (lines[0] == "")
            {
                throw new MissingPasswordException();
            }
            else if (lines[1] == "")
            {
                throw new MissingPhoneNumberException();
            }
            else if (lines[2] == "")
            {
                throw new MissingUserIDException();
            }

            PasswordSecurity oldPass = ctx.Passwords
                .First(x => x.PassId.Equals(passID));

            ctx.Passwords.Remove(oldPass);

            PasswordSecurity newPass = new PasswordSecurity()
            {
                PassId = oldPass.PassId,
                userInformation = oldPass.userInformation,
                TotallySecuredVeryHashedPassword = lines[0],
                RecoverPhoneNumber = lines[1],
                UserId = int.Parse(lines[2])
            };

            ctx.Passwords.Add(newPass);
            ctx.SaveChanges();

        }
        public void Delete(int passId)
        {

            var us = from x in ctx.Passwords
                     select x;

            foreach (var item in us)
            {
                if (item.UserId.Equals(passId))
                {
                    ctx.Remove(item);
                }
            }
            ctx.SaveChanges();

        }
        public IQueryable<PasswordSecurity> ReadAll()
        {
            var us = from x in ctx.Passwords
                     select x;

            IQueryable<PasswordSecurity> list = us.AsQueryable().Select(x => x);


            return list;
        }

    }
}
