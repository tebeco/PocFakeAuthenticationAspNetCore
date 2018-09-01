using System;
using System.Collections.Generic;
using System.Text;
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
            _configuration.GetConnectionString(ElasticSearchOptions.ElasticSearchSectionName);      
        }
    }
}
