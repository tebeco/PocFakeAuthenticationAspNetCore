using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace LogAsCode
{
    public class ElasticSearchOptionsSetup : IConfigureOptions<ElasticSearchOptions>
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;

        public ElasticSearchOptionsSetup(IConfiguration configuration, IServiceCollection services)
        {
            _services = services;
            _configuration = configuration;
        }

        public void Configure(ElasticSearchOptions options)
        {
            var x = _configuration.GetSection(ElasticSearchOptions.ElasticSearchSectionName).Get<ElasticSearchOptions>();
            _services.Configure<ElasticSearchOptions>();
            // options.CircuitBreaker.DelayBeforeRetry = _options.CircuitBreaker.DelayBeforeRetry;
            // options.CircuitBreaker.ErrorNumberBeforeSwitchOff = _options.CircuitBreaker.ErrorNumberBeforeSwitchOff;
        }
    }
}
