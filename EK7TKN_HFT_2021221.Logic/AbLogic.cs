using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public abstract class AbLogic
    {
        Repo_User userRepo;
        Repo_Password passwordRepo;
        Repo_Run runRepo;

        public AbLogic(IRepo user, IRepo pass, IRepo run)
        {
            this.userRepo = (Repo_User)user;
            this.passwordRepo = (Repo_Password)pass;
            this.runRepo = (Repo_Run)run;
        }
    }
}
