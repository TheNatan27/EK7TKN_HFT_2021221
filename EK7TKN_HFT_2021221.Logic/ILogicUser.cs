using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public interface ILogicUser : ILogic
    {
        public IEnumerable<string> GetEmailOfWeakPasswordUsers();
        public IEnumerable<string> GetCompetitorsEmailAddress();
        public IEnumerable<string> GetAmericanUsersNames();
        public IEnumerable<string> GetLongDistanceCompetitorsNames();
        public IEnumerable<string> GetNameOfLongDistanceOldRunners();



    }
}
