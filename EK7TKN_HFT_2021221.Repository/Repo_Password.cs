using EK7TKN_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class Repo_Password : AbRepo<Repo_Password>
    {
        xDbContext ctx;
        public Repo_Password(xDbContext context) : base(context)
        {
            this.ctx = context;
        }
        

    }
}
