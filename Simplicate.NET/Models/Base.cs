
using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Base
{

    public string Id { get; set; } = null!;

    [JsonPropertyName("simplicate_url")]
    public string? SimplicateUrl { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

}