using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Project : Base
{

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("project_status")]
    public ProjectStatusLookup Status { get; set; } = null!;

    [JsonPropertyName("hours_rate_type")]
    public string? RateType { get; set; }

    [JsonPropertyName("organization")]
    public NameLookup? Organization { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }

    [JsonPropertyName("contact_id")]
    public string? ContactId { get; set; }

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

    [JsonPropertyName("timeline_email_address")]
    public string? TimelineEmailAddress { get; set; }

    [JsonPropertyName("employees")]
    public IEnumerable<ProjectEmployee> Employees { get; set; } = null!;

    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }

    [JsonPropertyName("my_organization_profile")]
    public MyOrganizationLookup MyOrganization { get; set; } = null!;

    [JsonPropertyName("my_organization_profile_id")]
    public string MyOrganizationId { get; set; } = null!;

    [JsonPropertyName("project_manager")]
    public NameLookup? ProjectManager { get; set; }

    [JsonPropertyName("budget")]
    public ProjectBudget Budget { get; set; } = null!;




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

public class ProjectStatusLookup 
{

   [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
}


public class ProjectStatus : LabelLookup
{

    [JsonPropertyName("color")]
    public string? Color { get; set; }
}


public class ProjectBudget
{
    [JsonPropertyName("costs")]
    public BudgetStatus Costs { get; set; } = null!;

    [JsonPropertyName("hours")]
    public BudgetStatus Hours { get; set; } = null!;

    [JsonPropertyName("total")]
    public BudgetStatus Total { get; set; } = null!;
}


public class BudgetStatus
{
    [JsonPropertyName("value_spent")]
    public decimal? Spent { get; set; }

    [JsonPropertyName("value_budget")]
    public decimal? Budget { get; set; }
}

public class NewProject
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("project_manager_id")]
    public string? ProjectManagerId { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }

    [JsonPropertyName("contact_id")]
    public string? ContactId { get; set; }

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