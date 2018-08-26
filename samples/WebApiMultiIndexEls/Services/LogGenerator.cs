using System;
using Microsoft.Extensions.Logging;

namespace WebApiMultiIndexEls.Services
{

    public class LogGenerator : ILogGenerator
    {
        private readonly ILogger<LogGenerator> _logger;

        public LogGenerator(ILogger<LogGenerator> logger)
        {
            _logger = logger;
        }

        public void Unhandled()
        {
            throw new Exception("fail");
        }

        public void Trace()
        {
            _logger.LogTrace("Using _logger.Trace with just a string");
        }

        public void Debug()
        {
            _logger.LogDebug("Using _logger.Debug with just a string");
        }

        public void Info()
        {
            _logger.LogInformation("Using _logger.LogInformation with just a string");
        }

        public void Warn()
        {
            _logger.LogWarning("Using _logger.LogWarning with just a string");
        }

        public void Error()
        {
            _logger.LogError("Using _logger.LogError with just a string");
        }


        public void ErrorFromException(Exception ex)
        {
            _logger.LogError(ex, "Using _logger.LogError with exception payload");
        }

        public void Critical()
        {
            _logger.LogCritical("Using _logger.LogCritical with just a string");
        }
    }
}