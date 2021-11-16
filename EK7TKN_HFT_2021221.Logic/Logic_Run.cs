using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public class Logic_Run : AbLogic, ILogic
    {
        Repo_Password passwordRepo;
        Repo_Run runRepo;
        Repo_User userRepo;
        public Logic_Run(IRepo user, IRepo pass, IRepo run) : base(user, pass, run)
        {
            this.userRepo = (Repo_User)user;
            this.passwordRepo = (Repo_Password)pass;
            this.runRepo = (Repo_Run)run;
        }

        public void Create()
        {
            runRepo.Create();
        }

        public void Delete()
        {
            runRepo.Delete();
        }

        public void Read()
        {
            runRepo.Read();
        }

        public void Update()
        {
            runRepo.Update();
        }
        public IQueryable<RunInformation> ReadAll()
        {
            return runRepo.ReadAll();
        }
    }
}
