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

    [JsonPropertyName("message_type")]
    public MessageType? MessageType { get; set; }

    [JsonPropertyName("linked_to")]
    public IEnumerable<LabelTypeLookup>? LinkedTo { get; set; }

    public IEnumerable<LabelTypeLookup>? LinkedToNotEmpty
    {
        get
        {
            return LinkedTo?.Where(a => !string.IsNullOrEmpty(a.Label));
        }
        set { }
    }

    public string? LinkedToOrganization
    {
        get
        {
            return LinkedToNotEmpty?.FirstOrDefault(g => g.Type == "organization")?.Id;
        }
        set { }
    }

    public string? LinkedToPerson
    {
        get
        {
            return LinkedToNotEmpty?.FirstOrDefault(g => g.Type == "person")?.Id;
        }
        set { }
    }

    public string? LinkedToSales
    {
        get
        {
            return LinkedToNotEmpty?.FirstOrDefault(g => g.Type == "sales")?.Id;
        }
        set { }
    }

    public string? LinkedToProject
    {
        get
        {
            return LinkedToNotEmpty?.FirstOrDefault(g => g.Type == "project")?.Id;
        }
        set { }
    }

    public string? LinkedToEmployee
    {
        get
        {
            return LinkedToNotEmpty?.FirstOrDefault(g => g.Type == "employee")?.Id;
        }
        set { }
    }

    public string? LinkedToInvoice
    {
        get
        {
            return LinkedToNotEmpty?.FirstOrDefault(g => g.Type == "invoice")?.Id;
        }
        set { }
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