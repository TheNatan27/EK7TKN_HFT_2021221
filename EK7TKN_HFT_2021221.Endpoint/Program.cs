using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Endpoint
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //UserTest users = new UserTest(context);

            //foreach (var item in users.userId)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            Console.WriteLine("Hello honlap");

            CreateHostBuilder(args).Build().Run();


        }

        //public class UserTest : Repo_User
        //{
        //    public List<int> userId { get; set; }
        //    public UserTest(xDbContext Context) : base(context)
        //    {
        //        foreach (var item in Context.Users)
        //        {
        //            userId.Add(item.UserID);
        //        }
        //    }
        //}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
