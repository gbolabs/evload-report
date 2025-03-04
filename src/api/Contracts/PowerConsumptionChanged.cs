using Coravel.Events.Interfaces;

public class PowerConsumptionChanged : IEvent
{
    public double BeforeAActPower { get; set; }
    public double BeforeBActPower { get; set; }
    public double BeforeCActPower { get; set; }
    public double AfterAActPower { get; set; }
    public double AfterBActPower { get; set; }
    public double AfterCActPower { get; set; }
}