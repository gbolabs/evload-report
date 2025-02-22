using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using shelly_connector.Models;

namespace shelly_connector;

public class ShellyDataProvider(
    HttpClient httpClient,
    IOptionsMonitor<EnvironmentConfiguration> configuration,
    ILogger<ShellyDataProvider> logger)
{
    public async Task<EmStatus?> GetEmStatusAsync(CancellationToken cancellationToken = default)
    {
        var host = configuration.CurrentValue.Host;
        var response = await httpClient.GetAsync($"{host}/rpc/Em.GetStatus?id=0", cancellationToken);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(cancellationToken);


        return JsonConvert.DeserializeObject<EmStatus>(content);
    }

    public async Task<EmData?> GetEmCountersAsync(CancellationToken cancellationToken = default)
    {
        var host = configuration.CurrentValue.Host;
        var response = await httpClient.GetAsync($"{host}/rpc/EmData.GetStatus?id=0", cancellationToken);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync(cancellationToken);


        return JsonConvert.DeserializeObject<EmData>(content);
    }
}