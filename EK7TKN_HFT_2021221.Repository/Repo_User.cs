using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class Repo_User : AbRepo<UserInformation>
    {
        xDbContext CTX;
        public void GetAllUserIDs()
        {
            List<UserInformation> users = CTX.Users.ToList();

            foreach (var item in users)
            {
                Console.WriteLine(item.UserID);
            }
        }
        public Repo_User(xDbContext context) : base(context)
        {
            this.CTX = context;
        }
    }
}
