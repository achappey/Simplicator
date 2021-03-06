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

    public OrganizationLookup Organization { get; set; } = null!;

    public bool Billable { get; set; }

    [JsonPropertyName("project_number")]
    public string? ProjectNumber { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    public IEnumerable<ProjectEmployee> Employees { get; set; } = null!;

    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }
}

public class ProjectLookup
{

    public string? Name { get; set; }

    public string Id { get; set; } = null!;

    [JsonPropertyName("project_number")]
    public string ProjectNumber { get; set; } = null!;

    public OrganizationLookup Organization { get; set; } = null!;

}

public class ProjectStatus
{

    public string Id { get; set; } = null!;
    
    public string? Label { get; set; }

    public string? Color { get; set; }
}