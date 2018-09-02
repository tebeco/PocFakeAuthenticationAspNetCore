using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LogAsCode
{
    public class ElasticSearchOptionsSetup : IConfigureOptions<ElasticSearchOptions>
    {
        private readonly IConfiguration _configuration;

        public ElasticSearchOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(ElasticSearchOptions options)
        {
            var _options = _configuration.GetSection(ElasticSearchOptions.ElasticSearchSectionName).Get<ElasticSearchOptions>();
            options.CircuitBreaker.DelayBeforeRetry = _options.CircuitBreaker.DelayBeforeRetry;
            options.CircuitBreaker.ErrorNumberBeforeSwitchOff = _options.CircuitBreaker.ErrorNumberBeforeSwitchOff;
        }
    }
}
