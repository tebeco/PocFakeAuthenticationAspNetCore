using Microsoft.AspNetCore.Hosting;

public static class LogAsCodeWebHostBuilderExtensions
{

    public static IWebHostBuilder AddLogAsCode(this IWebHostBuilder webHostBuilder)
    {
        webHostBuilder.ConfigureServices(collection => collection.AddSingleton<ILoggerFactory>(services => new SomeLoggerFactory(logger, dispose)));

        return hostBuilder;
    }
}
