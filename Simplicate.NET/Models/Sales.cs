using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Sales : Base
{

    public string? Subject { get; set; }

    public string? Note { get; set; }

    [JsonPropertyName("chance_to_score")]
    public double ChanceToScore { get; set; }

    [JsonPropertyName("expected_revenue")]
    public decimal ExpectedRevenue { get; set; }

    public OrganizationLookup Organization { get; set; } = null!;

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("expected_closing_date")]
    public string? ExpectedClosingDate { get; set; }

    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }

}
