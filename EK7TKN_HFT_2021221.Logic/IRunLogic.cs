using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public interface IRunLogic : ILogic
    {
        public IEnumerable<string> GetTimeOfPremiumCompetitors();
        public IEnumerable<int> GetRunIDOfPremiumUsers();
        public IEnumerable<int> GetRunIDOfLongDistanceJuniorRunners();
        public IEnumerable<string> GetLocationOfChonkers();
        public IEnumerable<string> GetLocationOfJuniorPremiumUsers();
    }
}
