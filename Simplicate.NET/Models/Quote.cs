using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Quote : Base
{

    [JsonPropertyName("quote_subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("valid_days")]
    public int ValidDays { get; set; }

    [JsonPropertyName("total_excl")]
    public decimal TotalExcl { get; set; }

    [JsonPropertyName("total_incl")]
    public decimal TotalIncl { get; set; }

    [JsonPropertyName("total_vat")]
    public decimal TotalVat { get; set; }

    [JsonPropertyName("quote_number")]
    public string QuoteNumber { get; set; } = null!;

    [JsonPropertyName("quote_date")]
    public string? QuoteDate { get; set; }

    [JsonPropertyName("sales_id")]
    public string? SalesId { get; set; }

    [JsonPropertyName("quotetemplate")]
    public QuoteTemplate QuoteTemplate { get; set; } = null!;

    [JsonPropertyName("quotestatus")]
    public QuoteStatus QuoteStatus { get; set; } = null!;

    

}


public class QuoteStatus : LabelLookup
{
}



public class QuoteTemplate : LabelLookup
{
}