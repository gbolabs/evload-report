using Contracts;
using Contracts.Models;

namespace evload_report.Models;

public class LoadSession : ILoadSession
{
    public uint Id { set; get; }
    public DateTimeOffset StartTimestamp { set; get; }
    public DateTimeOffset? EndTimestamp { set; get; }
    public double StartEnergy { set; get; }
    public double? EndEnergy { set; get; }
    
    public double? TotalEnergy => EndEnergy - StartEnergy;
    public double Tariff { set; get; }
    
    public uint? ExpenseReportId { set; get; }
}