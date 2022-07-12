using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Installment
{

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
    public double Percentage { get; set; }
    public double Order { get; set; }

    [JsonPropertyName("expiration_date")]
    public string ExpirationDate { get; set; } = null!;

    public string Status { get; set; } = null!;

    [JsonPropertyName("invoiced_date")]
    public string InvoiceDate { get; set; } = null!;

    [JsonPropertyName("invoice_id")]
    public string InvoiceId { get; set; } = null!;

}