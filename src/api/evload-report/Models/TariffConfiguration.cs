namespace evload_report.Models;

public class TariffConfiguration
{
    public Tariff[] Tariffs { init; get; } = [];
}

public class Tariff
{
    public DateTimeOffset ValidFrom { init; get; }
    public DateTimeOffset ValidTo { init; get; }
    public double CentimesPerKwh { init; get; }
    public bool IsVatIncluded { init; get; } = true;
}