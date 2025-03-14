using AFZV31_HFT_2023241.Endpoint.Services;
using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Models;
using AFZV31_HFT_2023241.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace AnnualDbApp.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddTransient<AnnualDbContext>();

            services.AddTransient<IRepository<Annual>, AnnualRepostitory>();
            services.AddTransient<IRepository<Area>, AreaRepostitory>();
            services.AddTransient<IRepository<Order>, OrderRepostitory>();
   
            services.AddTransient<IAnnualLogic, AnnualLogic>();
            services.AddTransient<IAreaLogic, AreaLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AnnualDbApp.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnnualDbApp.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
               .AllowCredentials()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithOrigins("http://localhost:26644"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
