using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class ProjectEmployee
{
    public string? Id { get; set; } = null!;
    
    [JsonPropertyName("employee_id")]
    public string? EmployeeId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("tariff")]
    public decimal? Tariff { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("declarable")]
    public bool Declarable { get; set; }

}