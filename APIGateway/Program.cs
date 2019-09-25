using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\logs");
            string logs_path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "logs\\gatewayapp.txt");
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .WriteTo.File(logs_path, rollingInterval: RollingInterval.Day)
               .CreateLogger();

            try
            {
                CreateWebHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseStartup<Startup>();
    }
}
