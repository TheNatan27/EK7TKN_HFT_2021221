using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Logic
{
    public class Logic_Run : IRunLogic
    {
        Repo_Password passwordRepo;
        Repo_Run runRepo;
        Repo_User userRepo;
        public Logic_Run(IRepository<UserInformation> user, IRepository<PasswordSecurity> pass, IRepository<RunInformation> run) 
        {
            this.userRepo = (Repo_User)user;
            this.passwordRepo = (Repo_Password)pass;
            this.runRepo = (Repo_Run)run;
        }

        //CRUD Methods

        //Single table
        private IEnumerable<int> GetRunIDOfLongRuns()
        {
            List<int> lista = new List<int>();

            var sue = from r in runRepo.ReadAll()
                      where r.Distance > 30
                      select r;

            foreach (var item in sue)
            {
                lista.Add(item.RunID);
            }

            return lista;
        }


        //Multi table
        public IEnumerable<int> GetRunIDOfPremiumUsers()
        {
            List<int> lista = new List<int>();

            var sue = from r in runRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on r.UserID equals u.userID
                      where u.premium.Equals(true)
                      select r.RunID;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<string> GetTimeOfPremiumCompetitors()
        {
            List<string> lista = new List<string>();

            var sue = from r in runRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on r.UserID equals u.userID
                      where (r.IsCompetition.Equals(true) && u.premium.Equals(true))
                      select r.Time;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<int> GetRunIDOfLongDistanceJuniorRunners()
        {
            List<int> lista = new List<int>();
            List<int> longLista = (List<int>)this.GetRunIDOfLongRuns();

            var sue = from r in runRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on r.UserID equals u.userID
                      where (longLista.Contains(r.RunID) && u.age < 18)
                      select r.RunID;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<string> GetLocationOfChonkers()
        {
            List<string> lista = new List<string>();

            var sue = from r in runRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on r.UserID equals u.userID
                      where u.weight > 90 && u.height < 170
                      select r.Location;


            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<string> GetLocationOfJuniorPremiumUsers()
        {
            List<string> lista = new List<string>();

            var sue = from r in runRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on r.UserID equals u.userID
                      where (u.age < 18 && u.premium.Equals(true))
                      select r.Location;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }



        //Non CRUD Methods
        public void Create(string json)
        {
            RunInformation jRun = JsonConvert.DeserializeObject<RunInformation>(json);
            runRepo.Create(jRun);
        }

        public void Delete(int runID)
        {
            runRepo.Delete(runID);
        }

        public RunInformation Read(int runID)
        {
            return runRepo.Read(runID);
        }

        public void Update(string json)
        {
            RunInformation jRun = JsonConvert.DeserializeObject<RunInformation>(json);
            runRepo.Update(jRun);
        }
        public IQueryable<RunInformation> ReadAll()
        {
            return runRepo.ReadAll();
        }
    }
}
