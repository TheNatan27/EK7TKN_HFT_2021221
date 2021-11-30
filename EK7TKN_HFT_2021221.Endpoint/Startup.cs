using EK7TKN_HFT_2021221.Data;
using EK7TKN_HFT_2021221.Logic;
using EK7TKN_HFT_2021221.Models;
using EK7TKN_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace EK7TKN_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IPassLogic, Logic_Password>();
            services.AddScoped<IPassRepository, Repo_Password>();

            services.AddScoped<IRunLogic, Logic_Run>();
            services.AddScoped<IRunRepository, Repo_Run>();

            services.AddScoped<IUserLogic, Logic_User>();
            services.AddScoped<IUserRepository, Repo_User>();

            services.AddScoped<xDbContext, xDbContext >();

            services.AddControllers().AddNewtonsoftJson();



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


