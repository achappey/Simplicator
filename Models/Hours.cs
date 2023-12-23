using System.Text.Json.Serialization;

namespace Simplicator.Models;

public class Hours
{

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    public string? ProjectServiceId { get; set; } 


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
    public string? Status { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    public string? EmployeeWorkEmail { get; set; }
}