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

    [JsonPropertyName("status")]
    public SalesStatus? Status { get; set; }

    [JsonPropertyName("progress")]
    public SalesProgress? Progress { get; set; }

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

}

public class SalesStatus : LabelLookup
{
}


public class RevenueGroup : LabelLookup
{
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