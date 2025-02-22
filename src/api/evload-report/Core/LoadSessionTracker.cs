using Contracts.Models;
using Coravel.Events.Interfaces;
using evload_report.Models;
using loadsession_detector;
using persistence;

namespace evload_report.Core;

public class LoadSessionTracker(
    LoadSessionStorage storage,
    EnergyCounterProvider energyCounterProvider,
    IEnergyTariffProvider tariffProvider,
    ILogger<LoadSessionTracker> logger) : IListener<LoadSessionDetectedEvent>
{
    public async Task HandleAsync(LoadSessionDetectedEvent broadcasted)
    {
        // Check if a load session is already open
        var session = await storage.ActiveSession().ConfigureAwait(false);
        if (session != null)
        {
            logger.LogWarning("Load session already active, ignoring new event");
        }
        
        // Get counters data
        var counters = await energyCounterProvider.GetEmCountersAsync().ConfigureAwait(false);
        if (counters == null)
        {
            logger.LogError("Could not retrieve current counters");
            return;
        }
        
        // Create a new load session
        var newSession = new LoadSession
        {
            Tariff = await tariffProvider.GetCurrentTariff().ConfigureAwait(false),
            StartEnergy = counters.TotalAct,
            StartTimestamp = DateTimeOffset.Now
        };
        await storage.AddAsync(newSession);
        
        logger.LogInformation("New load session started. Energy: {Energy}, Tariff: {Tariff}", newSession.StartEnergy, newSession.Tariff);
    }
}