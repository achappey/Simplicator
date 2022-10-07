
using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class DefaultService
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("price_editable")]
    public bool PriceEditable { get; set; }

    [JsonPropertyName("price")]
    public string? Price { get; set; }

    [JsonPropertyName("revenue_group")]
    public LabelLookup? RevenueGroup { get; set; }

    [JsonPropertyName("vat_class")]
    public VatClass? VatClass { get; set; }
}