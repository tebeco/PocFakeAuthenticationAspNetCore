using System;

namespace LogAsCode
{
    public class ElasticSearchOptions
    {
        public const string ElasticSearchSectionName = "LogAsCode::ElasticSearch";

        public Uri[] Nodes { get; set; }

        public CircuitBreakerConfiguration CircuitBreaker { get; set; }
    }
}
