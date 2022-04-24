using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public class Logic_Run : IRunLogic
    {
        Repo_Password passwordRepo;
        Repo_Run runRepo;
        Repo_User userRepo;
        public Logic_Run(IUserRepository user, IPassRepository pass, IRunRepository run) 
        {
            this.userRepo = (Repo_User)user;
            this.passwordRepo = (Repo_Password)pass;
            this.runRepo = (Repo_Run)run;
        }

        //CRUD Methods

        //Single table
      

        //Multi table


        public RunInformation Read(int runID)
        {
            return runRepo.Read(runID);
        }


    }
}
