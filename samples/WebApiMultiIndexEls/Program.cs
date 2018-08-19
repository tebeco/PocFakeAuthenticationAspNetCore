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
using SerilogAsCode;

namespace WebApiMultiIndexEls
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var logAsCode = new MySerilogLoggerFactory().GetDefaultLogger();
            Log.Logger = globalLogger;

            try
            {
                globalLogger.Information("Starting web host");

                CreateWebHostBuilder(args)
                    .Build()
                    .Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }


        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                ;
    }
}
