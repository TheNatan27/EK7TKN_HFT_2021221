using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EK7TKN_HFT_2021221.Logic
{
    public class Logic_User : IUserLogic
    {
        Repo_Password passwordRepo;
        Repo_Run runRepo;
        Repo_User userRepo;
        public Logic_User(IUserRepository user, IPassRepository pass, IRunRepository run) 
        {
            this.userRepo = (Repo_User)user;
            this.passwordRepo = (Repo_Password)pass;
            this.runRepo = (Repo_Run)run;
        }

        //Non CRUD Methods
        private IEnumerable<int> GetUserIDsOfAllRuns()
        {
            List<int> lista = new List<int>();

            var sue = from r in runRepo.ReadAll()
                      select r.UserID;

            foreach (var item in sue)
            {
                //Console.WriteLine(item);
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<KeyValuePair<double, string>> ReadRunsOfUser(int userID)
        {

            var oke = from u in userRepo.ReadAll()
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where r.UserID.Equals(userID)
                      select new KeyValuePair<double, string>(
                          r.Distance, r.Time);


            return oke;

        }

        //Multi Table
        public IEnumerable<string> GetEmailOfWeakPasswordUsers()
        {
            List<string> lista = new List<string>();

            var sue = from u in userRepo.ReadAll()
                      join p in passwordRepo.ReadAll()
                      on u.UserID equals p.UserId
                      where p.TotallySecuredVeryHashedPassword.Length < 10
                      select u;

            foreach (var item in sue)
            {
                lista.Add(item.Email);
            }
            return (lista);
        }
        public IEnumerable<string> GetCompetitorsEmailAddress()
        {
            List<string> lista = new List<string>();

            var oke = from u in userRepo.ReadAll()
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where r.IsCompetition.Equals(true)
                      select u.Email;

            foreach (var item in oke)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<string> GetAmericanUsersNames()
        {
            List<string> lista = new List<string>();

            var oke = from u in userRepo.ReadAll()
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where r.Location.Contains("United States")
                      select u.Full_Name;

            foreach (var item in oke)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<string> GetLongDistanceCompetitorsNames()
        {
            List<string> lista = new List<string>();

            var oke = from u in userRepo.ReadAll()
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where r.IsCompetition.Equals(true) && r.Distance>30
                      select u.Full_Name;

            foreach (var item in oke)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<string> GetNameOfLongDistanceOldRunners()
        {
            List<string> lista = new List<string>();

            var oke = from u in userRepo.ReadAll()
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where r.Distance > 30 && u.Age > 70
                      select u.Full_Name;

            foreach (var item in oke)
            {
                lista.Add(item);
            }

            return lista;
        }

        //CRUD Methods
        public void Create(string json)
        {
            userRepo.Create(json);
        }

        public void Delete(int userID)
        {
            userRepo.Delete(userID);
        }

        public UserInformation Read(int userID)
        {
            return userRepo.Read(userID);
        }

        public void Update(string json, int userID)
        {
            userRepo.Update(json, userID);
        }
        public IQueryable<UserInformation> ReadAll()
        {
            return userRepo.ReadAll();
        }
    }
}


