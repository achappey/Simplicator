using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class SalesService
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("default_service_id")]
    public string? DefaultServiceId { get; set; }

    [JsonPropertyName("sales_id")]
    public string SalesId { get; set; } = null!;

    [JsonPropertyName("invoice_method")]
    public string InvoiceMethod { get; set; } = null!;

    [JsonPropertyName("hour_types")]
    public IEnumerable<SalesHourType>? HourTypes { get; set; }

    [JsonPropertyName("vat_class")]
    public VatClassLookup? VatClass { get; set; } = null;


    

}
