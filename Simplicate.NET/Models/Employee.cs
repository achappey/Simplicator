using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Employee : Base
{
    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("function")]
    public string? Function { get; set; }

    [JsonPropertyName("work_phone")]
    public string? WorkPhone { get; set; }

    [JsonPropertyName("work_email")]
    public string? WorkEmail { get; set; }

    [JsonPropertyName("work_mobile")]
    public string? WorkMobile { get; set; }

    [JsonPropertyName("employment_status")]
    public string? EmploymentStatus { get; set; }

    [JsonPropertyName("hourly_sales_tariff")]
    public decimal? HourlySalesTariff { get; set; }

    [JsonPropertyName("hourly_cost_tariff")]
    public decimal? HourlyCostTariff { get; set; }

    [JsonPropertyName("timeline_email_address")]
    public string? TimelineEmailAddress { get; set; }

    [JsonPropertyName("is_user")]
    public bool IsUser { get; set; }

    [JsonPropertyName("avatar")]
    public Avatar? Avatar { get; set; }

    [JsonPropertyName("supervisor")]
    public EmployeeLookup? Supervisor { get; set; }

    [JsonPropertyName("custom_fields")]
    public IEnumerable<CustomField>? CustomFields { get; set; }

    [JsonPropertyName("teams")]
    public IEnumerable<NameLookup>? Teams { get; set; }

    [JsonPropertyName("person")]
    public PersonLookup? Person { get; set; }

}

public class EmployeeLookup : NameLookup
{
    [JsonPropertyName("person_id")]
    public string? PersonId { get; set; }
}


public class PersonLookup : NameLookup
{
    [JsonPropertyName("address")]
    public Address? Address { get; set; }
}

public class Avatar
{
    [JsonPropertyName("url_small")]
    public string? UrlSmall { get; set; }

    [JsonPropertyName("url_large")]
    public string? UrlLarge { get; set; }

    [JsonPropertyName("initials")]
    public string? Initials { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; }

}
