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

    [JsonPropertyName("sent_at")]
    public string? SentAt { get; set; }

    [JsonPropertyName("quotetemplate")]
    public QuoteTemplateLookup QuoteTemplate { get; set; } = null!;

    [JsonPropertyName("quotestatus")]
    public QuoteStatusLookup QuoteStatus { get; set; } = null!;

    

}

public class QuoteStatusLookup
{
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("color")]
    public string? Color { get; set; }

}


public class QuoteStatus : LabelLookup
{   
 

}


public class QuoteTemplate : LabelLookup
{
  

}

public class QuoteTemplateLookup
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

}