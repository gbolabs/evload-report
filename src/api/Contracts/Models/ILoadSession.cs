namespace Contracts.Models;

public interface ILoadSession
{
    uint Id { get; set; }
    DateTimeOffset StartTimestamp { get; set; }
    DateTimeOffset? EndTimestamp { get; set; }
    double StartEnergy { get; set; }
    double? EndEnergy { get; set; }
    double? TotalEnergy { get; }
    double Tariff { get; set; }
    uint? ExpenseReportId { get; set; }
}