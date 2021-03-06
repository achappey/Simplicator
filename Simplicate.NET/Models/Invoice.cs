using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Invoice : Base
{

    public InvoiceStatus? Status { get; set; }

    public string? Date { get; set; }

    public string Subject { get; set; } = null!;

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

public class InvoiceStatus
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }
}