using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LogAsCode
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddLogAsCodeElasticSearch(this IServiceCollection services)
        {
            services.AddSingleton<IConfigureOptions<ElasticSearchOptions>, ElasticSearchOptionsSetup>();
            return services;
        }

        public static IServiceCollection AddLogAsCodeElasticSearch(this IServiceCollection services, Uri[] nodes)
        {
            services.AddLogAsCodeElasticSearch(options =>
            {
                options.Nodes = nodes;
            });
            return services;
        }

        public static IServiceCollection AddLogAsCodeElasticSearch(this IServiceCollection services, Action<ElasticSearchOptions> configure)
        {
            services.Configure(configure);
            return services;
        }
    }
}
