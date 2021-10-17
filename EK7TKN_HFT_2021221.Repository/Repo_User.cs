using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    class Repo_User
    {
        public int UserId { get; set; }
        public int Weight { get; set; }

        public Repo_User(int userId, int weight)
        {
            UserId = userId;
            Weight = weight;
        }
    }
}
