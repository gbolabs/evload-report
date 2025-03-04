using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using shelly_connector;

var builder = new HostBuilder();

builder.ConfigureHostConfiguration(configHost =>
{
    configHost.AddEnvironmentVariables();
});

builder.ConfigureServices((hostContext, services) =>
{
    services.AddShellyConnector(hostContext.Configuration);
});

builder.UseConsoleLifetime();

var app = builder.Build();

await app.RunAsync();