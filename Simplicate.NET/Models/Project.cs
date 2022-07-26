using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Project : Base
{

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("project_status")]
    public ProjectStatus Status { get; set; } = null!;

    [JsonPropertyName("hours_rate_type")]
    public string? RateType { get; set; }

    [JsonPropertyName("organization")]
    public OrganizationLookup Organization { get; set; } = null!;

    [JsonPropertyName("billable")]
    public bool Billable { get; set; }

    [JsonPropertyName("project_number")]
    public string? ProjectNumber { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("employees")]
    public IEnumerable<ProjectEmployee> Employees { get; set; } = null!;

    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }
}

public class ProjectLookup
{

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("project_number")]
    public string ProjectNumber { get; set; } = null!;

    [JsonPropertyName("organization")]
    public OrganizationLookup Organization { get; set; } = null!;

}

public class ProjectStatus
{

    public string Id { get; set; } = null!;
    
    public string? Label { get; set; }

    public string? Color { get; set; }
}