using Contracts;
using Contracts.Models;
using persistence.Entities;

namespace persistence.Entities;

public class ExpenseReport : EntityBase, IExpenseReport
{
    public DateTimeOffset Timestamp { get; set; }
    public double? TotalEnergy { get; set; }
    public double? TotalCost { get; set; }
    public bool? IsClosed { get; set; }

    public uint[]? LoadSessionIds { get; set; }
    public IEnumerable<LoadSession>? LoadSession { get; set; }
}