using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Message
{

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    [JsonPropertyName("created_by")]
    public TypeLookup? CreatedBy { get; set; }

    [JsonPropertyName("message_type")]
    public MessageType? MessageType { get; set; }

    [JsonPropertyName("linked_to")]
    public IEnumerable<LabelTypeLookup>? LinkedTo { get; set; }

}


public class MessageType : LabelLookup
{
    [JsonPropertyName("blocked")]
    public bool Blocked { get; set; }

}

public class NewMessage
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("messagetype_id")]
    public string MessagetypeId { get; set; } = null!;

    [JsonPropertyName("created_by_id")]
    public string CreatedById { get; set; } = null!;

    [JsonPropertyName("display_date")]
    public string? DisplayDate { get; set; }

    [JsonPropertyName("linked_to")]
    public MessageLink LinkedTo { get; set; } = null!;

}

public class MessageLink
{
  /*  [JsonPropertyName("sales_id")]
    public string? SalesId { get; set; }

    [JsonPropertyName("project_id")]
    public string? ProjectId { get; set; }

    [JsonPropertyName("invoice_id")]
    public string? InvoiceId { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }*/

    [JsonPropertyName("employee_id")]
    public string? EmployeeId { get; set; }



}