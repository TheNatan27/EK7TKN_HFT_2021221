using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public interface IPassLogic : ILogic
    {
        public IEnumerable<int> GetOldPeoplesPassID();
        public IEnumerable<int> GetOldPeoplesPassIDWithWeakPassword();
        public IEnumerable<int> GetPassIDOfPremiumUsers();
        public IEnumerable<string> GetPhoneNumberOfPremiumUsers();
        public IEnumerable<string> GetPhoneNumberOfCompetitors();
        public IEnumerable<string> GetPasswordOfUserByName();
    }
}
