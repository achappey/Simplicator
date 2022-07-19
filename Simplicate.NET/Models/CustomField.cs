using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class CustomField
{

    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Label { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string Type { get; set; } = null!;

    [JsonPropertyName("render_type")]
    public string RenderType { get; set; } = null!;

    [JsonPropertyName("value_type")]
    public string ValueType { get; set; } = null!;

    public IEnumerable<CustomFieldOption>? Options { get; set; }

}


public class CustomFieldOption
{
    public string Label { get; set; } = null!;

    public string Value { get; set; } = null!;

}