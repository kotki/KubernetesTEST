using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace KubernetesTEST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("aspnetapp.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile("aspnetapp.conf", optional: true, reloadOnChange: true);
                    config.AddJsonFile("aspnetapp2.json", optional: true, reloadOnChange: true);
                    config.AddJsonFile("aspnetapp2.conf", optional: true, reloadOnChange: true);
                })
                .UseStartup<Startup>();
    }
}
