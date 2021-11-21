using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EK7TKN_HFT_2021221.Logic
{
    public class Logic_User : AbLogic, ILogicUser
    {
        Repo_Password passwordRepo;
        Repo_Run runRepo;
        Repo_User userRepo;
        public Logic_User(IRepo user, IRepo pass, IRepo run) : base(user, pass, run)
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
        public void Create()
        {
            userRepo.Create();
        }

        public void Delete()
        {
            userRepo.Delete();
        }

        public void Read()
        {
            userRepo.Read();
        }

        public void Update()
        {
            userRepo.Update();
        }
        public IQueryable<UserInformation> ReadAll()
        {
            return userRepo.ReadAll();
        }
    }
}

//new UserInformation() { Full_Name="	Chrisse Lacroix	",Email="	clacroix0@europa.eu	",Age=  64  ,Height=    185 ,Weight=    103 ,UserID=    1   ,Premium=   true   },
//new UserInformation() { Full_Name = "	Ivett Raddish	", Email = "	iraddish1@webnode.com	", Age = 51, Height = 168, Weight = 92, UserID = 2, Premium = true },
//new UserInformation() { Full_Name = "	Lief Sheirlaw	", Email = "	lsheirlaw2@addtoany.com	", Age = 58, Height = 173, Weight = 66, UserID = 3, Premium = false },
//new UserInformation() { Full_Name = "	Tiff Weems	", Email = "	tweems3@addtoany.com	", Age = 55, Height = 184, Weight = 80, UserID = 4, Premium = false },
//new UserInformation() { Full_Name = "	Nada Grgic	", Email = "	ngrgic4@sitemeter.com	", Age = 66, Height = 187, Weight = 82, UserID = 5, Premium = false }

//new RunInformation() { RunID = 2, UserID = 5, Distance = 29.5, Time = "00:38:06", IsCompetition = true, Location = "	Poland	" },
//new RunInformation() { RunID = 3, UserID = 2, Distance = 37.2, Time = "00:72:95", IsCompetition = false, Location = "	Poland	" },
//new RunInformation() { RunID = 4, UserID = 4, Distance = 6.0, Time = "00:06:62", IsCompetition = false, Location = "	Netherlands	" },
//new RunInformation() { RunID = 5, UserID = 3, Distance = 6.4, Time = "00:09:96", IsCompetition = false, Location = "	Poland	" },
//new RunInformation() { RunID = 6, UserID = 5, Distance = 8.5, Time = "00:61:21", IsCompetition = false, Location = "	United States	" },
//new RunInformation() { RunID = 7, UserID = 3, Distance = 38.4, Time = "00:18:18", IsCompetition = false, Location = "	Poland	" },
//new RunInformation() { RunID = 8, UserID = 4, Distance = 23.4, Time = "00:49:48", IsCompetition = false, Location = "	Poland	" },
//new RunInformation() { RunID = 9, UserID = 2, Distance = 13.5, Time = "00:97:20", IsCompetition = false, Location = "	Poland	" },
//new RunInformation() { RunID = 10, UserID = 3, Distance = 42.3, Time = "00:09:14", IsCompetition = false, Location = "	United States	" }

//new PasswordSecurity() { PassId = 1, UserId = 1, TotallySecuredVeryHashedPassword = "	8USrXl708t	", RecoverPhoneNumber = "	06 707 1849" },
//new PasswordSecurity() { PassId = 2, UserId = 2, TotallySecuredVeryHashedPassword = "	kUXTEef	", RecoverPhoneNumber = "	06 468 9848" },
//new PasswordSecurity() { PassId = 3, UserId = 3, TotallySecuredVeryHashedPassword = "	gRAPzMUp	", RecoverPhoneNumber = "	06 622 1971" },
//new PasswordSecurity() { PassId = 4, UserId = 4, TotallySecuredVeryHashedPassword = "	WVjebFQt2	", RecoverPhoneNumber = "	06 480 0104" },
//new PasswordSecurity() { PassId = 5, UserId = 5, TotallySecuredVeryHashedPassword = "	1oQypGOQ	", RecoverPhoneNumber = "	06 032 0862" }


