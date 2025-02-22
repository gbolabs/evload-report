using Newtonsoft.Json;

namespace shelly_connector.Models;

public class EmStatus
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("a_current")]
    public double ACurrent { get; set; }

    [JsonProperty("a_voltage")]
    public double AVoltage { get; set; }

    [JsonProperty("a_act_power")]
    public double AActPower { get; set; }

    [JsonProperty("a_aprt_power")]
    public double AApptPower { get; set; }

    [JsonProperty("a_pf")]
    public double APf { get; set; }

    [JsonProperty("a_freq")]
    public double AFreq { get; set; }

    [JsonProperty("b_current")]
    public double BCurrent { get; set; }

    [JsonProperty("b_voltage")]
    public double BVoltage { get; set; }

    [JsonProperty("b_act_power")]
    public double BActPower { get; set; }

    [JsonProperty("b_aprt_power")]
    public double BApptPower { get; set; }

    [JsonProperty("b_pf")]
    public double BPf { get; set; }

    [JsonProperty("b_freq")]
    public double BFreq { get; set; }

    [JsonProperty("c_current")]
    public double CCurrent { get; set; }

    [JsonProperty("c_voltage")]
    public double CVoltage { get; set; }

    [JsonProperty("c_act_power")]
    public double CActPower { get; set; }

    [JsonProperty("c_aprt_power")]
    public double CApptPower { get; set; }

    [JsonProperty("c_pf")]
    public double CPf { get; set; }

    [JsonProperty("c_freq")]
    public double CFreq { get; set; }

    [JsonProperty("n_current")]
    public double? NCurrent { get; set; } // Nullable double for n_current

    [JsonProperty("total_current")]
    public double TotalCurrent { get; set; }

    [JsonProperty("total_act_power")]
    public double TotalActPower { get; set; }

    [JsonProperty("total_aprt_power")]
    public double TotalApptPower { get; set; }

    [JsonProperty("user_calibrated_phase")]
    public List<string> UserCalibratedPhase { get; set; } // Assuming it's a list of strings
}