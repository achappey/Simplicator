
using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Contract
{
    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("employee")]
    public NameLookup Employee { get; set; } = null!;

    [JsonPropertyName("contract_type")]
    public NameLookup ContractType { get; set; } = null!;

    [JsonPropertyName("employment_type")]
    public NameLookup EmploymentType { get; set; } = null!;

}
