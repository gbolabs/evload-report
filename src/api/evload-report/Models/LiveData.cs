namespace evload_report.Models;

public class LiveData
{
    public DateTimeOffset Timestamp { init; get; }
    public double ACurrent { init; get; }
    public double AActPower { init; get; }
    public double BCurrent { init; get; }
    public double BActPower { init; get; }
    public double CCurrent { init; get; }
    public double CActPower { init; get; }
}