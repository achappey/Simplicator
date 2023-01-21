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
    public string CreatedAt { get; set; } = null!;

    [JsonPropertyName("created_by")]
    public TypeLookup? CreatedBy { get; set; }

    public string CreatedById => CreatedBy?.Id;

    [JsonPropertyName("message_type")]
    public MessageType? MessageType { get; set; }

    public string MessageTypeId => MessageType?.Id;

    [JsonPropertyName("linked_to")]
    public IEnumerable<LabelTypeLookup>? LinkedTo { get; set; }

    public IEnumerable<LabelTypeLookup> LinkedToNotEmpty => LinkedTo?.Where(a => !string.IsNullOrEmpty(a.Label));

    public string LinkedToOrganization => LinkedToNotEmpty?.GetLinkedId("organization");
    public string LinkedToPerson => LinkedToNotEmpty?.GetLinkedId("person");
    public string LinkedToSales => LinkedToNotEmpty?.GetLinkedId("sales");
    public string LinkedToProject => LinkedToNotEmpty?.GetLinkedId("project");
    public string LinkedToEmployee => LinkedToNotEmpty?.GetLinkedId("employee");
    public string LinkedToInvoice => LinkedToNotEmpty?.GetLinkedId("invoice");

}


public static class LabelTypeLookupExtensions
{
    public static string GetLinkedId(this IEnumerable<LabelTypeLookup> linkedTo, string type)
    {
        return linkedTo?.FirstOrDefault(g => g.Type == type)?.Id;
    }
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
    [JsonPropertyName("employee_id")]
    public string? EmployeeId { get; set; }



}