using EK7TKN_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public interface IPassRepository 
    {
        public IQueryable<PasswordSecurity> ReadAll();
        public void Create(string json);
        public IQueryable<PasswordSecurity> Read(int userID);
        public void Delete(int passId);
        public void Update(string json, int passId);
    }
}
