using Contracts;
using Contracts.Models;

namespace evload_report.Models;

public class ExpenseReport : IExpenseReport
{
    public uint Id { set; get; }
    public DateTimeOffset Timestamp { set; get; }
    public double? TotalEnergy { set; get; }
    public double? TotalCost { set; get; }

    public bool? IsClosed { set; get; } = false;

    public uint[]? LoadSessionIds { set; get; } = [];
}