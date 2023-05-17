using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class VatClass
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("percentage")]
    public double Percentage { get; set; }

}



public class VatClassLookup
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

     [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("percentage")]
    public double Percentage { get; set; }

}
