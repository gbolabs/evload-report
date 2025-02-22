using Newtonsoft.Json;

namespace shelly_connector.Models;

public class EmData
{
    [JsonProperty("id")]
    public int Id { get; init; }

    [JsonProperty("a_total_act_energy")]
    public double ATotalActEnergy { get; init; }

    [JsonProperty("a_total_act_ret_energy")]
    public double ATotalActRetEnergy { get; init; }

    [JsonProperty("b_total_act_energy")]
    public double BTotalActEnergy { get; init; }

    [JsonProperty("b_total_act_ret_energy")]
    public double BTotalActRetEnergy { get; init; }

    [JsonProperty("c_total_act_energy")]
    public double CTotalActEnergy { get; init; }

    [JsonProperty("c_total_act_ret_energy")]
    public double CTotalActRetEnergy { get; init; }

    [JsonProperty("total_act")]
    public double TotalAct { get; init; }

    [JsonProperty("total_act_ret")]
    public double TotalActRet { get; init; }
    
    
}