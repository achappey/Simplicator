using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Service
{

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("explanation")]
    public string? Explanation { get; set; }

    [JsonPropertyName("default_service_id")]
    public string? DefaultServiceId { get; set; }

    [JsonPropertyName("invoice_date")]
    public string? InvoiceDate { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("invoice_method")]
    public string InvoiceMethod { get; set; } = null!;

    [JsonPropertyName("use_in_resource_planner")]
    public bool UseInResourcePlanner { get; set; }

    [JsonPropertyName("vat_class")]
    public VatClass VatClass { get; set; } = null!;

    [JsonPropertyName("track_hours")]
    public bool TrackHours { get; set; }

    [JsonPropertyName("track_cost")]
    public bool TrackCost { get; set; }

}