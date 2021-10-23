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

            

            CreateHostBuilder(args).Build().Run();
            xDbContext context = new xDbContext();
            Repo_User testUser = new Repo_User(context);

            testUser.GetAllUserIDs();

            Console.WriteLine("Hello honlap");

        }

        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
