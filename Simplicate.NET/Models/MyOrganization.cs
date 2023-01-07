
using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class MyOrganization
{

    [JsonPropertyName("name")]
    public string Name { get; set; }  = null!;

    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; }  = null!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("blocked")]
    public bool Blocked { get; set; }

    [JsonPropertyName("bank_account")]
    public string? BankAccount { get; set; }

    [JsonPropertyName("vat_number")]
    public string? VatNumber { get; set; }

    [JsonPropertyName("coc_code")]
    public string? CocCode { get; set; }

}


public class MyOrganizationLookup
{
    [JsonPropertyName("organization")]
    public NameLookup? Organization { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
}


public class Team
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}