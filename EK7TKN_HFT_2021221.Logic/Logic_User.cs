using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EK7TKN_HFT_2021221.Logic
{
    public class Logic_User : AbLogic, ILogic
    {
        Repo_Password passwordRepo;
        Repo_Run runRepo;
        Repo_User userRepo;
        public Logic_User(IRepo user, IRepo pass, IRepo run) : base(user, pass, run)
        {
            this.userRepo = (Repo_User)user;
            this.passwordRepo = (Repo_Password)pass;
            this.runRepo = (Repo_Run)run;
        }

        //Non CRUD Methods
        public IEnumerable<string> GetEmailOfWeakPasswordUsers()
        {
            List<string> lista = new List<string>();

            var sue = from u in userRepo.ReadAll()
                      join p in passwordRepo.ReadAll()
                      on u.UserID equals p.UserId
                      where p.TotallySecuredVeryHashedPassword.Length < 10
                      select u;

            foreach (var item in sue)
            {
                lista.Add(item.Email);
            }
            return (lista);
        }


        //CRUD Methods
        public void Create()
        {
            userRepo.Create();
        }

        public void Delete()
        {
            userRepo.Delete();
        }

        public void Read()
        {
            userRepo.Read();
        }

        public void Update()
        {
            userRepo.Update();
        }
        public IQueryable<UserInformation> ReadAll()
        {
            return userRepo.ReadAll();
        }
    }
}
