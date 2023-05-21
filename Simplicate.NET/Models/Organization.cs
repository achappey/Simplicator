
using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Organization : Base
{

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("linkedin_url")]
    public string? LinkedInUrl { get; set; }

    [JsonPropertyName("relation_number")]
    public string? RelationNumber { get; set; }

    [JsonPropertyName("coc_code")]
    public string? CocCode { get; set; }

    [JsonPropertyName("bank_account")]
    public string? BankAccount { get; set; }

    [JsonPropertyName("visiting_address")]
    public Address? VisitingAddress { get; set; }

    [JsonPropertyName("postal_address")]
    public Address? PostalAddress { get; set; }

    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }

    [JsonPropertyName("industry")]
    public NameLookup? Industry { get; set; }

    [JsonPropertyName("relation_type")]
    public RelationType? RelationType { get; set; }

    [JsonPropertyName("relation_manager")]
    public NameLookup? RelationManager { get; set; }

    [JsonPropertyName("teams")]
    public IEnumerable<NameLookup>? Teams { get; set; }


}

public class Industry
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
}

public class Address
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("line_1")]
    public string? Line1 { get; set; }

    [JsonPropertyName("line_2")]
    public string? Line2 { get; set; }

    [JsonPropertyName("postal_code")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("province")]
    public string? Province { get; set; }

    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

}