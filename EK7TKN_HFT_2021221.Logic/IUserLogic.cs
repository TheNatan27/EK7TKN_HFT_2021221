using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public interface IUserLogic 
    {
        public void Create(string json);
        public void Delete(int userID);
        public UserInformation Read(int userID);
        public void Update(string json, int userID);
        public IQueryable<UserInformation> ReadAll();

        public IEnumerable<KeyValuePair<double, string>> ReadRunsOfUser(int userID);

        public IEnumerable<string> GetEmailOfWeakPasswordUsers();
        public IEnumerable<string> GetCompetitorsEmailAddress();
        public IEnumerable<string> GetAmericanUsersNames();
        public IEnumerable<string> GetLongDistanceCompetitorsNames();
        public IEnumerable<string> GetNameOfLongDistanceOldRunners();



    }
}
