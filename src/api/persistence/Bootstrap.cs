using Microsoft.AspNetCore.Builder;

namespace persistence;

public static class Bootstrap
{
    public static async Task BootstrapPersistenceAsync(this IApplicationBuilder app, CancellationToken cancellationToken = default)
    {
        // // Migrate schema
        // var serviceScope = app.ApplicationServices.CreateScope();
        // using (serviceScope)
        // {
        //     var dbctx = serviceScope.ServiceProvider.GetService<MyDataContext>();
        //     await dbctx.Database.EnsureCreatedAsync(cancellationToken);
        //     await dbctx.Database.MigrateAsync(cancellationToken: cancellationToken);
        // }
    }
}