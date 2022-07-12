using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Project : Base
{

    public string? Name { get; set; }

    public string? Note { get; set; }

    [JsonPropertyName("project_status")]
    public ProjectStatus Status { get; set; } = null!;

    [JsonPropertyName("hours_rate_type")]
    public string? RateType { get; set; }

    public Organization Organization { get; set; } = null!;

    public bool Billable { get; set; }

    [JsonPropertyName("project_number")]
    public string? ProjectNumber { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    public IEnumerable<ProjectEmployee> Employees { get; set; } = null!;

}