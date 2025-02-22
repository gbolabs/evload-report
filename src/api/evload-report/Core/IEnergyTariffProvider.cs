namespace evload_report.Core;

public interface IEnergyTariffProvider
{
    Task<double> GetCurrentTariff();
}