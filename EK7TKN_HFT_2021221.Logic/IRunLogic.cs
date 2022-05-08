using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public interface IRunLogic 
    {
        public void Create(RunInformation json);
        public IQueryable<RunInformation> ReadAll();
        public RunInformation Read(int runID);
        public void Update(RunInformation json);
        public void Delete(int runID);

        public IEnumerable<string> GetTimeOfPremiumCompetitors();
        public IEnumerable<int> GetRunIDOfPremiumUsers();
        public IEnumerable<int> GetRunIDOfLongDistanceJuniorRunners();
        public IEnumerable<string> GetLocationOfChonkers();
        public IEnumerable<string> GetLocationOfJuniorPremiumUsers();
    }
}
