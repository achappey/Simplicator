using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Contract
{

    [JsonPropertyName("id")]
    public string Id { get; set; } =  null!;

    [JsonPropertyName("parttime_percentage")]
    public string? ParttimePercentage { get; set; }

    [JsonPropertyName("salary_fulltime")]
    public string? SalaryFulltime { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("employee")]
    public NameLookup? Employee { get; set; } = null!;

    [JsonPropertyName("employer")]
    public NameLookup? Employer { get; set; } = null!;

    [JsonPropertyName("employment_type")]
    public NameLookup? EmploymentType { get; set; } = null!;

    [JsonPropertyName("contract_type")]
    public NameLookup? ContractType { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

}
