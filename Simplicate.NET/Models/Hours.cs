using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Hours
{

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("employee")]
    public EmployeeLookup Employee { get; set; } = null!;

    public string EmployeeId
    {
        get
        {
            return Employee.Id;
        }
        set
        {
        }
    }

    [JsonPropertyName("project")]
    public ProjectLookup? Project { get; set; }

    public string? ProjectId
    {
        get
        {
            return Project?.Id;
        }
        set
        {
        }
    }


    [JsonPropertyName("projectservice")]
    public ProjectServiceLookup? ProjectService { get; set; }

    [JsonPropertyName("invoice_status")]
    public string? InvoiceStatus { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("hours")]
    public double Time { get; set; }

    [JsonPropertyName("tariff")]
    public decimal? Tariff { get; set; }

    [JsonPropertyName("billable")]
    public bool Billable { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

}


public class HourType
{
    [JsonPropertyName("budgeted_amount")]
    public decimal? BudgetedAmount { get; set; }

    [JsonPropertyName("tariff")]
    public decimal? Tariff { get; set; }

    [JsonPropertyName("billable")]
    public bool Billable { get; set; }

    [JsonPropertyName("hourstype_id")]
    public string HoursTypeId { get; set; } = null!;

}


public class SalesHourType
{
    [JsonPropertyName("budgeted_amount")]
    public decimal? BudgetedAmount { get; set; }

    [JsonPropertyName("tariff")]
    public decimal? Tariff { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
}