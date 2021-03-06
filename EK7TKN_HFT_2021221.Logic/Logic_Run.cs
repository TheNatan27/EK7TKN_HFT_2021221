using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
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
        public Logic_Run(IUserRepository user, IPassRepository pass, IRunRepository run) 
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
                      on r.UserID equals u.UserID
                      where u.Premium.Equals(true)
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
                      on r.UserID equals u.UserID
                      where (r.IsCompetition.Equals(true) && u.Premium.Equals(true))
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
                      on r.UserID equals u.UserID
                      where (longLista.Contains(r.RunID) && u.Age < 18)
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
                      on r.UserID equals u.UserID
                      where u.Weight > 90 && u.Height < 170
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
                      on r.UserID equals u.UserID
                      where (u.Age < 18 && u.Premium.Equals(true))
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
            runRepo.Create(json);
        }

        public void Delete(int runID)
        {
            runRepo.Delete(runID);
        }

        public RunInformation Read(int runID)
        {
            return runRepo.Read(runID);
        }

        public void Update(string json, int runID)
        {
            runRepo.Update(json, runID);
        }
        public IQueryable<RunInformation> ReadAll()
        {
            return runRepo.ReadAll();
        }
    }
}
