using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Installment
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("percentage")]
    public double Percentage { get; set; }

    [JsonPropertyName("order")]
    public double Order { get; set; }

    [JsonPropertyName("expiration_date")]
    public string ExpirationDate { get; set; } = null!;

    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("invoiced_date")]
    public string InvoicedDate { get; set; } = null!;

    [JsonPropertyName("invoice_id")]
    public string InvoiceId { get; set; } = null!;

}