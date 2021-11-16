using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public class Logic_Password : AbLogic, ILogic
    {
        Repo_Password passwordRepo;
        Repo_Run runRepo;
        Repo_User userRepo;
        public Logic_Password(IRepo user, IRepo pass, IRepo run) : base(user, pass, run)
        {
            this.userRepo = (Repo_User)user;
            this.passwordRepo = (Repo_Password)pass;
            this.runRepo = (Repo_Run)run;
        }

        //NON CRUD Methods

        public void test()
        {
            var fe = from u in userRepo.ReadAll()
                     select u.runInfo;

        }
        public IEnumerable<string> GetWeakPasswordUsers()
        {
            List<string> bruh = new List<string>();

            //var pas = from p in passwordRepo.ReadAll()
            //       select p.TotallySecureVeryHashedPassword;

            var pas = from p in passwordRepo.ReadAll()
                      select p.userInformation.First_Name;

            foreach (var item in pas)
            {
                if (item != null)
                {
                    bruh.Add(item);
                    Console.WriteLine(item.ToString());
                }
            }

            return (bruh);

        }




        //CRUD Methods
        public void Create()
        {
            passwordRepo.Create();
        }

        public void Delete()
        {
            passwordRepo.Delete();
        }

        public void Read()
        {
            passwordRepo.Read();
        }

        public void Update()
        {
            passwordRepo.Update();
        }
        public IQueryable<PasswordSecurity> ReadAll()
        {
            return passwordRepo.ReadAll();
        }
    }
}
