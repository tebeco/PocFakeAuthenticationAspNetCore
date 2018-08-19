using System;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace SerilogAsCode
{
    public class MySerilogLoggerFactory
    {
        public ILogger GetDefaultLogger()
        {
            var serilogLevelSwitch = new LoggingLevelSwitch();
            var elasticsearchSinkOptions = new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
            {
                IndexFormat = "logs-{0:yyyy.MM.dd}",
                FailureCallback = logEvent => { },
                EmitEventFailure = EmitEventFailureHandling.RaiseCallback
            };

            var defaultLogger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.ColoredConsole(levelSwitch: serilogLevelSwitch)
                .WriteTo.RollingFile("Logs\\DefaultLogger-{Date}.log")
                .WriteTo.Elasticsearch()
                .CreateLogger();

            return defaultLogger;
        }

        public ILogger GetConnectionLogger()
        {
            var serilogLevelSwitch = new LoggingLevelSwitch();
            var elasticsearchSinkOptions = new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
            {
                IndexFormat = "connections-{0:yyyy.MM.dd}",
                FailureCallback = logEvent => { },
                EmitEventFailure = EmitEventFailureHandling.RaiseCallback
            };

            var connectionLogger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.ColoredConsole(levelSwitch: serilogLevelSwitch)
                .WriteTo.RollingFile("Logs\\connections-{Date}.log")
                .CreateLogger();

            return connectionLogger;
        }
    }
}
