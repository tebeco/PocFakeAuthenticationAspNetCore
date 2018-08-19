using System;
using SerilogAsCode;

namespace SerilogAsCode
{
    public class MySerilogLoggerFactory
    {
        public ILogger GetDefaultLogger()
        {
            var globalLogger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            return globalLogger;
        }

    }
}
