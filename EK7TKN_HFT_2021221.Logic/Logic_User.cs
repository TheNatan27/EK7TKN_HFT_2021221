using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EK7TKN_HFT_2021221.Logic
{
    public class Logic_User : IUserLogic
    {
        Repo_Password passwordRepo;
        Repo_Run runRepo;
        Repo_User userRepo;
        public Logic_User(IUserRepository user, IPassRepository pass, IRunRepository run) 
        {
            this.userRepo = (Repo_User)user;
            this.passwordRepo = (Repo_Password)pass;
            this.runRepo = (Repo_Run)run;
        }

        //Non CRUD Methods
 



        //CRUD Methods
       

        public UserInformation Read(int userID)
        {
            return userRepo.Read(userID);
        }


    }
}


