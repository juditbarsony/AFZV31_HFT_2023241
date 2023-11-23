using AFZV31_HFT_2023241.Logic;
using AFZV31_HFT_2023241.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFZV31_HFT_2023241.Endpoint

{
    public class Program
    {
        static AnnualLogic annualLogic;
        static AreaLogic areaLogic;
        static OrderLogic orderLogic;
        public static void Main(string[] args)
        {
            var ctx = new AnnualDbContext();

            var annualRepo = new AnnualRepostitory(ctx);
            var areaRepo = new AreaRepostitory(ctx);
            var orderRepo = new OrderRepostitory(ctx);


            annualLogic = new AnnualLogic(annualRepo);
            areaLogic = new AreaLogic(areaRepo);
            orderLogic = new OrderLogic(orderRepo);

            //CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
