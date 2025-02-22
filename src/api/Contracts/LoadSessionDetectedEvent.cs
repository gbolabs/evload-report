using Coravel.Events.Interfaces;

namespace loadsession_detector;

public class LoadSessionDetectedEvent : IEvent
{
    public DateTimeOffset Timestamp { get; set; }
    public uint Type { get; set; }
    public double AActPower { get; set; }
    public double BActPower { get; set; }
    public double CActPower { get; set; }
    public double ACurrent { get; set; }
    public double BCurrent { get; set; }
    public double CCurrent { get; set; }
}