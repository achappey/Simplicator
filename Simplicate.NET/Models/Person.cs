
using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Person : Base
{

    [JsonPropertyName("full_name")]
    public string? FullName { get; set; }

    [JsonPropertyName("gender")]
    public string? Gender { get; set; }

    [JsonPropertyName("initials")]
    public string? Initials { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("family_name_prefix")]
    public string? FamilyNamePrefix { get; set; }

    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("linkedin_url")]
    public string? LinkedInUrl { get; set; }

    [JsonPropertyName("twitter_url")]
    public string? TwitterUrl { get; set; }

    [JsonPropertyName("facebook_url")]
    public string? FacebookUrl { get; set; }

    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; set; }

    [JsonPropertyName("relation_number")]
    public string? RelationNumber { get; set; }

    [JsonPropertyName("mailing_list_email")]
    public string? MailingListEmail { get; set; }

    [JsonPropertyName("invoice_receiver")]
    public string? InvoiceReceiver { get; set; }

    [JsonPropertyName("bank_account")]
    public string? BankAccount { get; set; }

    [JsonPropertyName("use_custom_salutation")]
    public bool UseCustomSalutation { get; set; }

    [JsonPropertyName("custom_salutation")]
    public string? CustomSalutation { get; set; }

    [JsonPropertyName("linked_as_contact_to_organization")]
    public IEnumerable<OrganizationContact> Organizations { get; set; } = null!;

    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }

     [JsonPropertyName("relation_manager")]
    public NameLookup? RelationManager { get; set; }    

     [JsonPropertyName("relation_type")]
    public RelationType? RelationType { get; set; }    

}


public class RelationType
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("label")]
    public string? Label { get; set; }
}


public class OrganizationContact
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("organization_id")]
    public string CustomSalutation { get; set; } = null!;

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }

    [JsonPropertyName("work_function")]
    public string? WorkFunction { get; set; }

    [JsonPropertyName("work_email")]
    public string? WorkEmail { get; set; }

    [JsonPropertyName("work_phone")]
    public string? WorkPhone { get; set; }

    [JsonPropertyName("work_mobile")]
    public string? WorkMobile { get; set; }


}