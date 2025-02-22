using shelly_connector;
using shelly_connector.Models;

namespace evload_report.Core;

public class EnergyCounterProvider(ShellyDataProvider shellyProvider)
{
    public async Task<EmData?> GetEmCountersAsync()
    {
        return await shellyProvider.GetEmCountersAsync().ConfigureAwait(false);
    }
}