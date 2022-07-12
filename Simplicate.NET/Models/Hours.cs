using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Hours
{

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

    public decimal? Tariff { get; set; }
    public bool Billable { get; set; }

    public string Status { get; set; } = null!;

}