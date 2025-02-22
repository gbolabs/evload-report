using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using shelly_connector.Models;

namespace shelly_connector;

public static class Registar
{
    public static IServiceCollection AddShellyConnector(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EnvironmentConfiguration>(configuration.GetSection("EnvironmentConfiguration"));
        services.AddHttpClient<ShellyDataProvider>();
        services.AddTransient<ShellyDataProvider>();
        
        return services;
    }
}