using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Invoice : Base
{

    public InvoiceStatus? Status { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; } = null!;

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("sending_method")]
    public string SendingMethod { get; set; } = null!;

    [JsonPropertyName("invoice_number")]
    public string InvoiceNumber { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public ProjectLookup Project { get; set; } = null!;

    [JsonPropertyName("total_excluding_vat")]
    public decimal TotalExcludingVat { get; set; }

    [JsonPropertyName("total_including_vat")]
    public decimal TotalIncludingVat { get; set; }

    [JsonPropertyName("total_outstanding")]
    public decimal TotalOutstanding { get; set; }

    [JsonPropertyName("total_vat")]
    public decimal TotalVat { get; set; }

    public OrganizationLookup Organization { get; set; } = null!;

}

