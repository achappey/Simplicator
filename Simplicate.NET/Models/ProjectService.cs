using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class ProjectService : Service
{
    [JsonPropertyName("project_id")]
    public string ProjectId { get; set; } = null!;

    public IEnumerable<Installment>? Installments { get; set; }

}


public class ProjectServiceLookup
{
    public string? Name { get; set; }

    public string Id { get; set; } = null!;

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("default_service_id")]
    public string? DefaultServiceId { get; set; }

    [JsonPropertyName("revenue_group_id")]
    public string? RevenueGroupId { get; set; }

}