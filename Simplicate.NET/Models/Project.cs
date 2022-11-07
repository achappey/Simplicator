using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Project : Base
{

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("project_status")]
    public ProjectStatus Status { get; set; } = null!;

    [JsonPropertyName("hours_rate_type")]
    public string? RateType { get; set; }

    [JsonPropertyName("organization")]
    public NameLookup? Organization { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }

    [JsonPropertyName("billable")]
    public bool Billable { get; set; }

    [JsonPropertyName("project_number")]
    public string? ProjectNumber { get; set; }

    [JsonPropertyName("invoice_reference")]
    public string? InvoiceReference { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("employees")]
    public IEnumerable<ProjectEmployee> Employees { get; set; } = null!;

    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }

    [JsonPropertyName("my_organization_profile")]
    public MyOrganizationLookup MyOrganization { get; set; } = null!;

    [JsonPropertyName("my_organization_profile_id")]
    public string MyOrganizationId { get; set; } = null!;

}

public class ProjectLookup : NameLookup
{
    [JsonPropertyName("project_number")]
    public string? ProjectNumber { get; set; }

    [JsonPropertyName("organization")]
    public NameLookup? Organization { get; set; }

}

public class LinkedProject
{
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("project_number")]
    public string? ProjectNumber { get; set; }
}

public class ProjectStatus : LabelLookup
{

    [JsonPropertyName("color")]
    public string? Color { get; set; }
}


public class NewProject 
{

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }

    [JsonPropertyName("billable")]
    public bool Billable { get; set; }

    [JsonPropertyName("project_number")]
    public string? ProjectNumber { get; set; }

    [JsonPropertyName("invoice_reference")]
    public string? InvoiceReference { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("my_organization_profile_id")]
    public string MyOrganizationId { get; set; } = null!;

    [JsonPropertyName("can_register_mileage")]
    public bool CanRegisterMileage { get; set; }

     [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomFieldLookup>? CustomFields { get; set; }

    


}