
using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class DefaultService
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("modified")]
    public string? Modified { get; set; }

    [JsonPropertyName("price_editable")]
    public bool PriceEditable { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("revenue_group")]
    public RevenueGroup? RevenueGroup { get; set; }

    [JsonPropertyName("vat_class")]
    public VatClass? VatClass { get; set; }

    

}