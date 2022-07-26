using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class RevenueGroup
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("label")]
    public string Label { get; set; } = null!;
}