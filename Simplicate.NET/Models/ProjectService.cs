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

public class NewProjectService
{
    public string? Name { get; set; }

    public string? Explanation { get; set; }

    public double Amount { get; set; }

    public decimal? Price { get; set; }

    [JsonPropertyName("project_id")]
    public string ProjectId { get; set; } = null!;

    [JsonPropertyName("use_in_resource_planner")]
    public bool UseInResourcePlanner { get; set; }

    [JsonPropertyName("vat_class_id")]
    public string VatClassId { get; set; } = null!;

    [JsonPropertyName("default_service_id")]
    public string? DefaultServiceId { get; set; }

    [JsonPropertyName("revenue_group_id")]
    public string? RevenueGroupId { get; set; }

    [JsonPropertyName("invoice_method")]
    public string InvoiceMethod { get; set; } = null!;

    [JsonPropertyName("track_hours")]
    public bool TrackHours { get; set; }

    [JsonPropertyName("track_cost")]
    public bool TrackCost { get; set; }

    [JsonPropertyName("hour_types")]
    public IEnumerable<HourType>? HourTypes { get; set; }


}
