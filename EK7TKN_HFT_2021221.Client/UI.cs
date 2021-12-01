using EK7TKN_HFT_2021221.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace EK7TKN_HFT_2021221.Client
{
    class UI
    {
        RestService rest;
        public UI(RestService service)
        {
            this.rest = service;
        }

        //Users
        public void AllUsers()
        {
            List<UserInformation> allusers = rest.GetAll<UserInformation>("user");

            foreach (var item in allusers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void ReadAUser()
        {
            Console.WriteLine("Enter user id: ");
            int id = int.Parse(Console.ReadLine());

            var se = rest.Get<UserInformation>( id, "user/read");

            Console.WriteLine(se.ToString());
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }
        public void CreateAUser()
        {
            Console.WriteLine("Enter full name:");
            string first = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter weight: ");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter height: ");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();

            UserInformation newUser = new UserInformation() {
                Full_Name = first, 
                Age = age, 
                Weight = weight, 
                Height = height, 
                Email = email };

            string jsonUser = JsonConvert.SerializeObject(newUser);

            rest.Post<string>(jsonUser, "user/post");
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }
        public void UpdateAUser()
        {
            Console.WriteLine("Enter full name:");
            string first = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter weight: ");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter height: ");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter the id of user you would like to update: ");
            int id = int.Parse(Console.ReadLine());

            UserInformation newUser = new UserInformation()
            {
                Full_Name = first,
                Age = age,
                Weight = weight,
                Height = height,
                Email = email
            };

            string jsonUser = JsonConvert.SerializeObject(newUser);

            rest.Put<string>(jsonUser, $"user/put/{id}");
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }
        public void DeleteAUser()
        {
            Console.WriteLine("Enter id of user to delete: ");
            int id = int.Parse(Console.ReadLine());

            rest.Delete(id, "user/delete");
            Console.WriteLine("Press enter to go back");
            Console.ReadLine();
        }

        public void ReadRunsOfUser()
        {
            Console.WriteLine("Enter user id:");
            int id = int.Parse(Console.ReadLine());

            List<KeyValuePair<double, string>> pairs = rest.GetAll<KeyValuePair<double, string>>($"user/ReadRunsOfUser/{id}");

            foreach (var item in pairs)
            {
                Console.WriteLine(item.Key.ToString(), item.Value);
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetEmailOfWeakPasswordUsers()
        {
            List<string> user1 = rest.GetAll<string>("user/GetEmailOfWeakPasswordUsers");

            foreach (var item in user1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetCompetitorsEmailAddress()
        {
            List<string> user2 = rest.GetAll<string>("user/GetCompetitorsEmailAddress");

            foreach (var item in user2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetAmericanUsersNames()
        {
            List<string> user3 = rest.GetAll<string>("user/GetAmericanUsersNames");

            foreach (var item in user3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetLongDistanceCompetitorsNames()
        {
            List<string> user4 = rest.GetAll<string>("user/GetLongDistanceCompetitorsNames");

            foreach (var item in user4)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetNameOfLongDistanceOldRunners()
        {
            List<string> user5 = rest.GetAll<string>("user/GetNameOfLongDistanceOldRunners");

            foreach (var item in user5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();        }

        //Runs
        public void AllRuns()
        {
            List<RunInformation> users = rest.GetAll<RunInformation>("run");

            foreach (var item in users)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void ReadARun()
        {
            Console.WriteLine("Enter run id: ");
            int id = int.Parse(Console.ReadLine());

            var se = rest.Get<RunInformation>(id, "run/read");

            Console.WriteLine(se.ToString());
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }
        public void CreateARun()
        {
            Console.WriteLine("Enter Distance:");
            double distance = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Time: ");
            string time = Console.ReadLine();
            Console.WriteLine("Enter Location: ");
            string location = Console.ReadLine();
            Console.WriteLine("Enter UserID: ");
            int uid = int.Parse(Console.ReadLine());

            RunInformation newRun = new RunInformation()
            {
                Distance = distance,
                Location = location,
                Time = time,
                UserID = uid
            };

            string jsonUser = JsonConvert.SerializeObject(newRun);

            rest.Post<string>(jsonUser, "run/post");
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }
        public void UpdateARun()
        {
            Console.WriteLine("Enter Distance:");
            double distance = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Time: ");
            string time = Console.ReadLine();
            Console.WriteLine("Enter Location: ");
            string location = Console.ReadLine();
            Console.WriteLine("Enter UserID: ");
            int uid = int.Parse(Console.ReadLine());

            RunInformation newRun = new RunInformation()
            {
                Distance = distance,
                Location = location,
                Time = time,
                UserID = uid
            };

            Console.WriteLine("Enter the id of run you would like to update: ");
            int id = int.Parse(Console.ReadLine());

            string jsonUser = JsonConvert.SerializeObject(newRun);

            rest.Put<string>(jsonUser, $"run/put/{id}");
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }
        public void DeleteARun()
        {
            Console.WriteLine("Enter id of run to delete: ");
            int id = int.Parse(Console.ReadLine());

            rest.Delete(id, "run/delete");
            Console.WriteLine("Press enter to go back");
            Console.ReadLine();
        }

        public void GetRunIDOfPremiumUsers()
        {
            List<int> run = rest.GetAll<int>("run/GetRunIDOfPremiumUsers");

            foreach (var item in run)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetTimeOfPremiumCompetitors()
        {
            List<string> run = rest.GetAll<string>("run/GetTimeOfPremiumCompetitors");

            foreach (var item in run)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetRunIDOfLongDistanceJuniorRunners()
        {
            List<int> run = rest.GetAll<int>("run/GetRunIDOfLongDistanceJuniorRunners");

            foreach (var item in run)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetLocationOfChonkers()
        {
            List<string> run = rest.GetAll<string>("run/GetLocationOfChonkers");

            foreach (var item in run)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetLocationOfJuniorPremiumUsers()
        {
            List<string> run = rest.GetAll<string>("run/GetLocationOfJuniorPremiumUsers");

            foreach (var item in run)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();        }

        //Passwords
        public void AllPasswords()
        {
            List<PasswordSecurity> passes = rest.GetAll<PasswordSecurity>("pass");

            foreach (var item in passes)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void ReadAPassword()
        {
            Console.WriteLine("Enter password id: ");
            int id = int.Parse(Console.ReadLine());

            var se = rest.Get<PasswordSecurity>(id, "pass/read");

            Console.WriteLine(se.ToString());
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }
        public void CreateAPassword()
        {
 
            Console.WriteLine("Enter Password:");
            string pass = (Console.ReadLine());
            Console.WriteLine("Enter Phone number: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter userid: ");
            int userid = int.Parse(Console.ReadLine());

            PasswordSecurity newPass = new PasswordSecurity()
            {
                TotallySecuredVeryHashedPassword = pass,
                RecoverPhoneNumber = phone,
                UserId = userid
            };

            string jsonUser = JsonConvert.SerializeObject(newPass);

            rest.Post<string>(jsonUser, "pass/post");
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }
        public void UpdateAPassword()
        {
            Console.WriteLine("Enter Password:");
            string pass = (Console.ReadLine());
            Console.WriteLine("Enter Phone number: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter userid: ");
            int userid = int.Parse(Console.ReadLine());

            PasswordSecurity newPass = new PasswordSecurity()
            {
                TotallySecuredVeryHashedPassword = pass,
                RecoverPhoneNumber = phone,
                UserId = userid
            };


            Console.WriteLine("Enter the id of password you would like to update: ");
            int id = int.Parse(Console.ReadLine());

            string jsonUser = JsonConvert.SerializeObject(newPass);

            rest.Put<string>(jsonUser, $"pass/put/{id}");
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }
        public void DeleteAPassword()
        {
            Console.WriteLine("Enter id of password to delete: ");
            int id = int.Parse(Console.ReadLine());

            rest.Delete(id, "pass/delete");
            Console.WriteLine("Press enter to go back");
            Console.ReadLine();
        }

        public void GetOldPeoplesPassID()
        {
            List<int> pass = rest.GetAll<int>("pass/GetOldPeoplesPassID");

            foreach (var item in pass)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetOldPeoplesPassIDWithWeakPassword()
        {
            List<int> pass = rest.GetAll<int>("pass/GetOldPeoplesPassIDWithWeakPassword");

            foreach (var item in pass)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetPassIDOfPremiumUsers()
        {
            List<int> pass = rest.GetAll<int>("pass/GetPassIDOfPremiumUsers");

            foreach (var item in pass)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetPhoneNumberOfPremiumUsers()
        {
            List<string> pass = rest.GetAll<string>("pass/GetPhoneNumberOfPremiumUsers");

            foreach (var item in pass)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();
        }
        public void GetPhoneNumberOfCompetitors()
        {
            List<string> pass = rest.GetAll<string>("pass/GetPhoneNumberOfCompetitors");

            foreach (var item in pass)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();        }

    }
}
