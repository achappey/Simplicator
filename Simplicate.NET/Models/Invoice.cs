using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Invoice : Base
{

    [JsonPropertyName("status")]
    public NameLookup? Status { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; } = null!;

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("sending_method")]
    public string SendingMethod { get; set; } = null!;

    [JsonPropertyName("invoice_number")]
    public string? InvoiceNumber { get; set; }

    [JsonPropertyName("comments")]
    public string Comments { get; set; } = null!;

    [JsonPropertyName("projects")]
    public IEnumerable<ProjectLookup>? Projects { get; set; }

    [JsonPropertyName("total_excluding_vat")]
    public decimal TotalExcludingVat { get; set; }

    [JsonPropertyName("total_including_vat")]
    public decimal TotalIncludingVat { get; set; }

    [JsonPropertyName("total_outstanding")]
    public decimal TotalOutstanding { get; set; }

    [JsonPropertyName("total_vat")]
    public decimal TotalVat { get; set; }

    [JsonPropertyName("organization")]
    public NameLookup? Organization { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("my_organization_profile")]
    public MyOrganizationLookup? MyOrganization { get; set; }

    [JsonPropertyName("my_organization_profile_id")]
    public string? MyOrganizationId { get; set; }

    [JsonPropertyName("timeline_email_address")]
    public string? TimelineEmailAddress { get; set; }

}


public class InvoiceStatus
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; }
}


public class NewInvoice
{
    [JsonPropertyName("payment_term_id")]
    public string PaymentTermId { get; set; } = null!;

    [JsonPropertyName("status_id")]
    public string StatusId { get; set; } = null!;

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; } = null!;

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("comments")]
    public string Comments { get; set; } = null!;

    [JsonPropertyName("project_id")]
    public string ProjectId { get; set; } = null!;

    [JsonPropertyName("organization_id")]
    public string OrganizationId { get; set; } = null!;

    [JsonPropertyName("my_organization_profile_id")]
    public string MyOrganizationProfileId { get; set; } = null!;

    [JsonPropertyName("invoice_lines")]
    public IEnumerable<InvoiceLine> InvoiceLines { get; set; } = null!;

}

public class InvoiceLine
{
    [JsonPropertyName("vat_class_id")]
    public string VatClassId { get; set; } = null!;

    [JsonPropertyName("revenue_group_id")]
    public string RevenueGroupId { get; set; } = null!;

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

}
