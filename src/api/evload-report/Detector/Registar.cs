using Coravel;

namespace evload_report.Detector;

public static class Registar
{
    public static IServiceCollection AddLoadSessionDetector(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddScheduler();
        services.Configure<PowerMonitoringOptions>(configuration.GetSection("PowerMonitoringOptions"));
        services.AddSingleton<PowerMonitor>();
        return services;
    }

    public static void UseLoadSessionDetector(this IApplicationBuilder app)
    {
        app.ApplicationServices.UseScheduler(scheduler =>
        {
            scheduler.Schedule<PowerMonitor>()
                .EveryFiveSeconds()
                .PreventOverlapping("PowerMonitor")
                .Zoned(TimeZoneInfo.Local);
        });
    }
}