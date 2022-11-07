using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class CustomField
{

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("label")]
    public string Label { get; set; } = null!;

    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("render_type")]
    public string RenderType { get; set; } = null!;

    [JsonPropertyName("value_type")]
    public string ValueType { get; set; } = null!;

    [JsonPropertyName("options")]
    public IEnumerable<CustomFieldOption>? Options { get; set; }

}


public class CustomFieldOption
{
    [JsonPropertyName("label")]
    public string Label { get; set; } = null!;

    [JsonPropertyName("value")]
    public string Value { get; set; } = null!;

}

public class CustomFieldLookup
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("value")]
    public string Value { get; set; } = null!;

}