using EK7TKN_HFT_2021221.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Client
{
    class UI
    {
        RestService rest;
        public UI(RestService service)
        {
            this.rest = service;
        }
        public void AllUsers()
        {
            List<UserInformation> allusers = rest.GetAll<UserInformation>("user");

            foreach (var item in allusers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        public void ReadAUser()
        {
            Console.WriteLine("Enter user id: ");
            int id = int.Parse(Console.ReadLine());

            var se = rest.Get<UserInformation>( id, "user/read");

            Console.WriteLine(se.ToString());
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

            rest.Put<string>(jsonUser, "user/put");
            Console.ReadLine();

        }
        public void DeleteAUser()
        {
            Console.WriteLine("Enter id of user to delete: ");
            int id = int.Parse(Console.ReadLine());

            rest.Delete(id, "user/delete");
            Console.ReadLine();
        }

    }
}
