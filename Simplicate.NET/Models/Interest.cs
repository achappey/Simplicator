
using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Interest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;


}
