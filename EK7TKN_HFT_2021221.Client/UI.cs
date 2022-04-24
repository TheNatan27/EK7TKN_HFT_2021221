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
        public void ReadAUser()
        {
            Console.WriteLine("Enter user id: ");
            int id = int.Parse(Console.ReadLine());

            var se = rest.Get<UserInformation>( id, "user/read");

            Console.WriteLine(se.ToString());
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }


        //Runs
        public void ReadARun()
        {
            Console.WriteLine("Enter run id: ");
            int id = int.Parse(Console.ReadLine());

            var se = rest.Get<RunInformation>(id, "run/read");

            Console.WriteLine(se.ToString());
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }
 

        //Passwords

        public void ReadAPassword()
        {
            Console.WriteLine("Enter password id: ");
            int id = int.Parse(Console.ReadLine());

            var se = rest.Get<PasswordSecurity>(id, "pass/read");

            Console.WriteLine(se.ToString());
            Console.WriteLine(" <==  Press enter to go back");
            Console.ReadLine();

        }


    }
}
