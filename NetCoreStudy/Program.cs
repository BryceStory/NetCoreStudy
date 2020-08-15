using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace NetCoreStudy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //  webBuilder.ConfigureKestrel((context,options)=>options.Limits.MaxRequestBodySize=1024);
                    //webBuilder.ConfigureLogging();    
                    //   webBuilder.UseStartup(Assembly.GetExecutingAssembly().FullName);
                   // webBuilder.UseContentRoot("文件名");  //默认使用wwwroot
                    webBuilder.UseStartup<Startup>();

                  //  webBuilder.us
                    
                });
    }
}
