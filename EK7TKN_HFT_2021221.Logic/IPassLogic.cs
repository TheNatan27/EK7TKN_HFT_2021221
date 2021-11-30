using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public interface IPassLogic 
    {
        public void Create(string json);

        public IQueryable<PasswordSecurity> ReadAll();
        public void Delete(int passId);
        public void Update(string filenameU, int userId);
        public IQueryable<PasswordSecurity> Read(int userId);

        public IEnumerable<int> GetOldPeoplesPassID();
        public IEnumerable<int> GetOldPeoplesPassIDWithWeakPassword();
        public IEnumerable<int> GetPassIDOfPremiumUsers();
        public IEnumerable<string> GetPhoneNumberOfPremiumUsers();
        public IEnumerable<string> GetPhoneNumberOfCompetitors();
        public IEnumerable<string> GetPasswordOfUserByName(string username);
    }
}
