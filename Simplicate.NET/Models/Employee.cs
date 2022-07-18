using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Employee : Base
{
    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("function")]
    public string? Function { get; set; }

    [JsonPropertyName("work_phone")]
    public string? WorkPhone { get; set; }

    [JsonPropertyName("work_email")]
    public string? WorkEmail { get; set; }

    [JsonPropertyName("work_mobile")]
    public string? WorkMobile { get; set; }

    [JsonPropertyName("employment_status")]
    public string? EmploymentStatus { get; set; }

    [JsonPropertyName("hourly_sales_tariff")]
    public decimal? HourlySalesTariff { get; set; }

    [JsonPropertyName("hourly_cost_tariff")]
    public decimal? HourlyCostTariff { get; set; }

    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }

}

public class EmployeeLookup
{
    public string? Name { get; set; }

    public string Id { get; set; } = null!;

    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }

}