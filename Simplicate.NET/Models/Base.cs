
using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Base
{

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("simplicate_url")]
    public string? SimplicateUrl { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

}


public class NameLookup
{

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
}


public class TypeLookup
{

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }
}


public class LabelTypeLookup : TypeLookup
{
    [JsonPropertyName("label")]
    public string? Label { get; set; }

}

public class LabelLookup
{
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
}


public class LinkedTo
{
    [JsonPropertyName("sales_id")]
    public string? SalesId { get; set; }

    [JsonPropertyName("project_id")]
    public string? ProjectId { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }
}

