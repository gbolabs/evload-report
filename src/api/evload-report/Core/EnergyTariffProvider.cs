namespace evload_report.Core;

public class EnergyTariffProvider : IEnergyTariffProvider
{
    public Task<double> GetCurrentTariff()
    {
        return Task.FromResult(0.37);
    }
}