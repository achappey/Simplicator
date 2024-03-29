using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Sales : Base
{

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("chance_to_score")]
    public double ChanceToScore { get; set; }

    [JsonPropertyName("expected_revenue")]
    public decimal ExpectedRevenue { get; set; }

    [JsonPropertyName("organization")]
    public NameLookup? Organization { get; set; }

    [JsonPropertyName("my_organization_profile_id")]
    public string? MyOrganizationProfileId { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("contact_id")]
    public string? ContactId { get; set; }

    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }

    [JsonPropertyName("status")]
    public SalesStatusLookup? Status { get; set; }

    [JsonPropertyName("progress")]
    public SalesProgressLookup? Progress { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("expected_closing_date")]
    public string? ExpectedClosingDate { get; set; }

    [JsonPropertyName("timeline_email_address")]
    public string? TimelineEmailAddress { get; set; }

    [JsonPropertyName("linked_project")]
    public LinkedProject? LinkedProject { get; set; }

    [JsonPropertyName("responsible_employee")]
    public NameLookup? ResponsibleEmployee { get; set; }

    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }

    [JsonPropertyName("source")]
    public NameLookup? Source { get; set; }


}

public class SalesStatus : LabelLookup
{
}

public class SalesSource
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class SalesStatusLookup
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("label")]
    public string? Label { get; set; }
}


public class RevenueGroup : LabelLookup
{
}



public class RevenueGroupLookup 
{
     [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("label")]
    public string? Label { get; set; }
}
public class SalesProgress : LabelLookup
{
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("chance_to_score")]
    public double? ChanceToScore { get; set; }

    [JsonPropertyName("position")]
    public int? Position { get; set; }
}


public class SalesProgressLookup
{
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("label")]
    public string? Label { get; set; }
}


public class NewSales 
{
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("chance_to_score")]
    public double ChanceToScore { get; set; }

    [JsonPropertyName("expected_revenue")]
    public decimal ExpectedRevenue { get; set; }

    [JsonPropertyName("my_organization_profile_id")]
    public string? MyOrganizationProfileId { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }

    [JsonPropertyName("contact_id")]
    public string? ContactId { get; set; }

    [JsonPropertyName("status_id")]
    public string? StatusId { get; set; }

    [JsonPropertyName("source_id")]
    public string? SourceId { get; set; }

    [JsonPropertyName("progress_id")]
    public string? ProgressId { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("expected_closing_date")]
    public string? ExpectedClosingDate { get; set; }

    [JsonPropertyName("responsible_employee_id")]
    public string? ResponsibleEmployee { get; set; }

    [JsonPropertyName("teams")]
    public IEnumerable<Team>? Teams { get; set; }
}