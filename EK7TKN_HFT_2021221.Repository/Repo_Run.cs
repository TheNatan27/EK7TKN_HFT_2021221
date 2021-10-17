using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    class Repo_Run
    {
        public int RunID { get; set; }
        public int UserID { get; set; }
        public double Distance { get; set; }
        public string Time { get; set; }

        public Repo_Run(int runid, int userid, double distance, string time)
        {
            this.RunID = runid;
            this.UserID = userid;
            this.Distance = distance;
            this.Time = time;
        }

    }
}
