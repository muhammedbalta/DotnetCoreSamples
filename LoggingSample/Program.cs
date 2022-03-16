using LoggingSample.Configuration;
using LoggingSample.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingSample
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
                    webBuilder.ConfigureLogging((hostingContext, logging) =>
                    {
                        logging.ClearProviders();
                        var config = new ColoredConsoleLoggerConfiguration()
                        {
                            LogLevel = LogLevel.Information,
                            Color = ConsoleColor.Red
                        };
                        logging.AddProvider(new ColoredConsoleLoggerProvider(config));
                    })
                    .UseStartup<Startup>();
                });
    }
}
