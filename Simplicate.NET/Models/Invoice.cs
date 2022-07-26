using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Invoice : Base
{

    [JsonPropertyName("status")]
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

    [JsonPropertyName("comments")]
    public string Comments { get; set; } = null!;

    [JsonPropertyName("project")]
    public ProjectLookup Project { get; set; } = null!;

    [JsonPropertyName("total_excluding_vat")]
    public decimal TotalExcludingVat { get; set; }

    [JsonPropertyName("total_including_vat")]
    public decimal TotalIncludingVat { get; set; }

    [JsonPropertyName("total_outstanding")]
    public decimal TotalOutstanding { get; set; }

    [JsonPropertyName("total_vat")]
    public decimal TotalVat { get; set; }

    [JsonPropertyName("organization")]
    public OrganizationLookup Organization { get; set; } = null!;

}

public class InvoiceStatus
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}