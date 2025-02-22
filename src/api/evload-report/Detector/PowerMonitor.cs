using Coravel.Events.Interfaces;
using Coravel.Invocable;
using loadsession_detector;
using Microsoft.Extensions.Options;
using shelly_connector;

namespace evload_report.Detector;

public class PowerMonitor(
    ShellyDataProvider shellyProvider,
    IOptionsMonitor<PowerMonitoringOptions> configuration,
    IDispatcher dispatcher,
    ILogger<PowerMonitor> logger) : IInvocable, ICancellableInvocable
{
    public async Task Invoke()
    {
        var threshold = configuration.CurrentValue.DetectionThresholdInWatts;
        var emStatus = await shellyProvider.GetEmStatusAsync(CancellationToken);

        if (emStatus == null)
        {
            logger.LogWarning("Could not retrieve current status");
            return;
        }

        // Simple check, if the current is above the detection threshold on all phases
        if (emStatus.AActPower > threshold && emStatus.BActPower > threshold && emStatus.CActPower > threshold)
        {
            // all three values must be close to each other to ensure a three-phase load
            var delta = configuration.CurrentValue.LoadDeltaBetweenPhasesInWatts;
            if (Math.Abs(emStatus.AActPower - emStatus.BActPower) < delta &&
                Math.Abs(emStatus.AActPower - emStatus.CActPower) < delta &&
                Math.Abs(emStatus.BActPower - emStatus.CActPower) < delta)
            {
                // Probability of a load session is high
                var payload = new LoadSessionDetectedEvent
                {
                    AActPower = emStatus.AActPower,
                    BActPower = emStatus.BActPower,
                    CActPower = emStatus.CActPower,
                    ACurrent = emStatus.ACurrent,
                    BCurrent = emStatus.BCurrent,
                    CCurrent = emStatus.CCurrent
                };
                
                await dispatcher.Broadcast(payload);
            }
        }
    }

    public CancellationToken CancellationToken { get; set; }
}

public class PowerMonitoringOptions
{
    public double DetectionThresholdInWatts { get; set; } = 250; // Default to 8A, approx 1.8kW on 230V 
    public double LoadDeltaBetweenPhasesInWatts { get; set; } = 50; // Default to 50W
}