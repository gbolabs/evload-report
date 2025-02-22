using Contracts;
using Contracts.Models;
using persistence.Entities;

namespace persistence.Entities;

public class LoadSession : EntityBase, ILoadSession
{
    public LoadSession()
    {
    }

    public DateTimeOffset StartTimestamp { get; set; }
    public DateTimeOffset? EndTimestamp { get; set; }
    public double StartEnergy { get; set; }
    public double? EndEnergy { get; set; }
    public double? TotalEnergy { get; }
    public double Tariff { get; set; }
    public uint? ExpenseReportId { get; set; }
    public ExpenseReport? ExpenseReport { get; set; }
}