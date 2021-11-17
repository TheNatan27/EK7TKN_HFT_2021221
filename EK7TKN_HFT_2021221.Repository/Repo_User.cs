﻿using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public class Repo_User : AbRepo<UserInformation>, IRepo
    {
        xDbContext CTX;

        #region Practice

        //public void GetAllUserIDs()
        //{
        //    List<UserInformation> users = CTX.Users.ToList();

        //    foreach (var item in users)
        //    {
        //        Console.WriteLine(item.UserID);
        //    }
        //}
        //public void GetChonkers()
        //{
        //    List<UserInformation> users = CTX.Users.ToList();

        //    var elemek = from x in CTX.Users
        //                 where x.Weight > 70
        //                 select x;
        //    foreach (var item in elemek)
        //    {
        //        Console.WriteLine("Id: "+item.UserID + "Weight: "+item.Weight);
        //    }
        //}
        //public void UpdateWeight()
        //{

        //    var elemek =
        //        from x in CTX.Users
        //        select x;

        //    foreach (var item in elemek)
        //    {
        //        item.Weight -= 10;
        //    }
        //    CTX.SaveChanges();
        //}
        ////public void AddUser()
        ////{
        ////    CTX.Users.Attach(new UserInformation() { UserID = 621, Weight = 100 });
        ////    CTX.Update(CTX.Users);
        ////}
        //public void LoseWeight()
        //{
        //    var elemek =
        //        from x in CTX.Users
        //        where  x.Weight > 40 && x.Weight <80
        //        select x;

        //    foreach (var item in elemek)
        //    {
        //        item.Weight -= 20;
        //    }
            
        //}
        //public void GetSmurfs()
        //{
        //    var elemek =
        //        from x in CTX.Users
        //        where x.Height < 165
        //        select x;

        //    foreach (var item in elemek)
        //    {
        //        Console.WriteLine(item.UserID + "  " + item.Height);
        //    }
        //}
        //public void GetRuns()
        //{
        //    var elemek =
        //        from x in CTX.Users
        //        select x;

        //    foreach (var item in elemek)
        //    {
        //        Console.WriteLine($"Id: {item.UserID}, Age: {item.Age}, Weight: {item.Weight}, Height: {item.Height}");
        //    }
        //}

        #endregion
        public Repo_User(xDbContext context) : base(context)
        {
            this.CTX = context;
        }

        //CRUD Methods

        public void Create()
        {
            
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter weight: ");
            double weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter height: ");
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();

            UserInformation newUser = new UserInformation() { Full_Name=name, Age = age, Weight = weight, Height = height, Email = email };

            Console.Clear();

            CTX.Users.Attach(newUser);
            CTX.SaveChanges();

            Console.WriteLine("User added!");

        }
        public void Read()
        {
            Console.WriteLine("Enter id: ");
            int id = int.Parse(Console.ReadLine());
            var us = from x in CTX.Users
                     select x;

            foreach (var item in us)
            {
                if (item.UserID == id)
                {
                    Console.WriteLine(item.ToString());
                }
                
            }
        }
        public IQueryable<UserInformation> ReadAll()
        {
            var us = from x in CTX.Users
                     select x;

            IQueryable<UserInformation> list = us.AsQueryable().Select(x => x);

            return list;
        }
        
        public void Update()
        {
            bool menu = true;

            Console.WriteLine("Enter Id of user you would like to update: ");
            int id = int.Parse(Console.ReadLine());

            var use = from x in CTX.Users
                      where x.UserID.Equals(id)
                      select x;

            

            while (menu)
            {
                Console.WriteLine("What would you like to update?");
                Console.WriteLine("1: Full name");
                Console.WriteLine("2: Age");
                Console.WriteLine("3: Weight");
                Console.WriteLine("4: Height");
                Console.WriteLine("5: Email adress");
                Console.WriteLine("6: Exit");


                int input = int.Parse(Console.ReadLine());
                Console.Clear();

                
                

                switch (input)
                {
                    case 1:
                    {
                            foreach (var item in use)
                            {
                                Console.WriteLine("Old name: " + item.Full_Name);
                            }
                            Console.WriteLine("Enter new name:");
                            string change = Console.ReadLine();

                            foreach (var item in use)
                            {
                                item.Full_Name = change;
                            }
                            Console.WriteLine("Done!");
                            Console.ReadLine();
                            Console.Clear();
                        break;
                    }

                    case 2:
                        {
                            foreach (var item in use)
                            {
                                Console.WriteLine("Old age: " + item.Age);
                            }
                            Console.WriteLine("Enter new age:");
                            int change = int.Parse(Console.ReadLine());

                            foreach (var item in use)
                            {
                                item.Age = change;
                            }
                            Console.WriteLine("Done!");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                            
                        }
                    case 3:
                        {
                            foreach (var item in use)
                            {
                                Console.WriteLine("Old weigh: " + item.Weight);
                            }
                            Console.WriteLine("Enter new weight:");
                            double change = double.Parse(Console.ReadLine());

                            foreach (var item in use)
                            {
                                item.Weight = change;
                            }
                            Console.WriteLine("Done!");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 4:
                        {
                            foreach (var item in use)
                            {
                                Console.WriteLine("Old height: " + item.Height);
                            }
                            Console.WriteLine("Enter new height:");
                            int change = int.Parse(Console.ReadLine());

                            foreach (var item in use)
                            {
                                item.Height = change;
                            }
                            Console.WriteLine("Done!");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 5:
                        {
                            foreach (var item in use)
                            {
                                Console.WriteLine("Old email: " + item.Email);
                            }
                            Console.WriteLine("Enter new email:");
                            string change = Console.ReadLine();

                            foreach (var item in use)
                            {
                                item.Email = change;
                            }
                            Console.WriteLine("Done!");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 6:
                        {
                            menu = false;
                            break;
                        }
                }

                

            }

            try
            {
                CTX.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void Delete()
        {
            Console.WriteLine("Enter Id of user you would like to delete:");
            int id = int.Parse(Console.ReadLine());

            var us = from x in CTX.Users
                     select x;

            foreach (var item in us)
            {
                if (item.UserID.Equals(id))
                {
                    CTX.Remove(item);
                }
            }
            CTX.SaveChanges();

        }

        public void ReadRunsOfUsers()
        {
            Console.WriteLine("Enter userId: ");
            int id = int.Parse(Console.ReadLine());

            var us = from x in CTX.Runs
                     where x.UserID.Equals(id)
                     select x;

            foreach (var item in us)
            {
                Console.WriteLine(item.ToString());
            }

            //var se = from x in CTX.Users
            //         where x.UserID.Equals(id)
            //         select x;

            //List<UserInformation> selist = se.ToList();

            //foreach (var item in se)
            //{
            //    Console.WriteLine(item);
            //}

        }
    }
}
