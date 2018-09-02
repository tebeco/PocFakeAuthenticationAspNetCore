using System;

namespace LogAsCode
{
    /*
    "LogAsCode": {
        "ElasticSearch": {
            "CircuitBreaker": {
                "ErrorNumberBeforeSwitchOff": 4,
                "DelayBeforeRetry": "00:00:10"
            },
            "Nodes": [
                "https://localhost:9200"
            ]
        },
        "File": {
            "Folder": ""
        }
    }
   */

    public class ElasticSearchOptions
    {
        public const string ElasticSearchSectionName = "LogAsCode:ElasticSearch";

        public Uri[] Nodes { get; set; } = Array.Empty<Uri>();

        public CircuitBreakerConfiguration CircuitBreaker { get; set; } = new CircuitBreakerConfiguration();
    }
}
