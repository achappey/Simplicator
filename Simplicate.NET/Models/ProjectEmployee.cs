using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class ProjectEmployee
{
    public string? Id { get; set; } = null!;
    
    [JsonPropertyName("employee_id")]
    public string? EmployeeId { get; set; }

    public string? Name { get; set; }

    public decimal? Tariff { get; set; }

    public double? Amount { get; set; }

    public bool Declarable { get; set; }



}