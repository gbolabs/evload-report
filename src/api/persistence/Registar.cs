using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using persistence.EF;

namespace persistence;

public static class Registar
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<LoadSessionStorage>();
        services.AddScoped<ExpenseReportStorage>();
        services.AddDbContext<MyDataContext>(options =>
            options.UseInMemoryDatabase("evload"));
        return services;
    }
}