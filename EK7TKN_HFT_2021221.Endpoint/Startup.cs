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
using EK7TKN_HFT_2021221.Endpoint.Services;
using Microsoft.AspNetCore.Diagnostics;

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

            services.AddSignalR();

            services.AddControllers().AddNewtonsoftJson();



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));
            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:12307"));


            app.UseRouting();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}


