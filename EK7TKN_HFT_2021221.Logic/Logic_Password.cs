using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public class Logic_Password : IPassLogic
    {
        Repo_Password passwordRepo;
        Repo_Run runRepo;
        Repo_User userRepo;
        public Logic_Password(IUserRepository user, IPassRepository pass, IRunRepository run) 
        {
            this.userRepo = (Repo_User)user;
            this.passwordRepo = (Repo_Password)pass;
            this.runRepo = (Repo_Run)run;
        }

        //Non CRUD Methods

        //Single table
        public IEnumerable<int> GetPeoplesPassIDWithWeakPasswords()
        {
            List<int> lista = new List<int>();

            var sue = from p in passwordRepo.ReadAll()
                      where p.TotallySecuredVeryHashedPassword.Length < 10
                      select p.PassId;

            foreach (var item in sue)
            {
                //Console.WriteLine(item);
                lista.Add(item);
            }
            return (lista);
        }

        //Multi table
        public IEnumerable<int> GetOldPeoplesPassID()
        {
            List<int> lista = new List<int>();

            var sue = from p in passwordRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on p.UserId equals u.UserID
                      where u.Age > 60
                      select p.PassId;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<int> GetOldPeoplesPassIDWithWeakPassword()
        {
            List<int> lista = new List<int>();

            List<int> oldLista = (List<int>)this.GetOldPeoplesPassID();
            List<int> weakLista = (List<int>)this.GetPeoplesPassIDWithWeakPasswords();

            var sue = from p in passwordRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on p.UserId equals u.UserID
                      where oldLista.Contains(p.PassId) && weakLista.Contains(p.PassId)
                      select p.PassId;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<int> GetPassIDOfPremiumUsers()
        {
            List<int> lista = new List<int>();

            var sue = from p in passwordRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on p.UserId equals u.UserID
                      where u.Premium.Equals(true)
                      select p.PassId;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;

        }
        public IEnumerable<string> GetPhoneNumberOfPremiumUsers()
        {
            List<string> lista = new List<string>();

            var sue = from p in passwordRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on p.UserId equals u.UserID
                      where u.Premium.Equals(true)
                      select p;

            foreach (var item in sue)
            {
                lista.Add(item.RecoverPhoneNumber);
            }

            return lista;

        }
        public IEnumerable<string> GetPhoneNumberOfCompetitors()
        {

            List<string> lista = new List<string>();

            var sue = from p in passwordRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on p.UserId equals u.UserID
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where r.IsCompetition.Equals(true)
                      select p.RecoverPhoneNumber;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
            

        //CRUD Methods
        public void Create(string json)
        {
            passwordRepo.Create(json);
        }

        public void Delete(int passId)
        {
            passwordRepo.Delete(passId);
        }

        public PasswordSecurity Read(int userId)
        {
            return passwordRepo.Read(userId);
        }

        public void Update(string json, int userId)
        {
            passwordRepo.Update(json, userId);
        }
        public IQueryable<PasswordSecurity> ReadAll()
        {
            return passwordRepo.ReadAll();
        }
    }
}
