using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public class Logic_Password : IPassLogic
    {
        Repo_Password passwordRepo;
        Repo_Run runRepo;
        Repo_User userRepo;
        public Logic_Password(IUserRepository user, IPassRepository pass, IRunRepository run) 
        {
            this.userRepo = (Repo_User)user;
            this.passwordRepo = (Repo_Password)pass;
            this.runRepo = (Repo_Run)run;
        }

        //Non CRUD Methods

        //Single table


        //Multi table


        public PasswordSecurity Read(int userId)
        {
            return passwordRepo.Read(userId);
        }

  
    }
}
