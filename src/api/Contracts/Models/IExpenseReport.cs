namespace Contracts.Models;

public interface IExpenseReport
{
    uint Id { get; set; }
    DateTimeOffset Timestamp { get; set; }
    double? TotalEnergy { get; set; }
    double? TotalCost { get; set; }
    bool? IsClosed { get; set; }
    uint[]? LoadSessionIds { get; set; }
}