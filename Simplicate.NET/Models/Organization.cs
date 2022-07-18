
using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Organization : Base
{

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }

    public string? Url { get; set; }

    public string? Note { get; set; }

    [JsonPropertyName("linkedin_url")]
    public string? LinkedInUrl { get; set; }

    [JsonPropertyName("relation_number")]
    public string? RelationNumber { get; set; }

    [JsonPropertyName("bank_account")]
    public string? BankAccount { get; set; }
    
    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }

}

public class OrganizationLookup
{
    public string? Name { get; set; }

    public string Id { get; set; } = null!;
}