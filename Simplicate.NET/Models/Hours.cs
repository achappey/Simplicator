using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Hours
{

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    public Employee Employee { get; set; } = null!;

    public Project Project { get; set; } = null!;

    public ProjectService ProjectService { get; set; } = null!;

    [JsonPropertyName("invoice_status")]
    public string? InvoiceStatus { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("hours")]
    public double Time { get; set; }

    [JsonPropertyName("tariff")]
    public decimal? Tariff { get; set; }

    [JsonPropertyName("billable")]
    public bool Billable { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("note")]
    public string? Note { get; set; }

}