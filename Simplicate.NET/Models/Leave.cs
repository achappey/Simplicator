using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class Leave : Base
{

 [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("leavetype")]
    public LeaveTypeLookup? LeaveType { get; set; }

    [JsonPropertyName("employee")]
    public NameLookup? Employee { get; set; }

    [JsonPropertyName("hours")]
    public double Time { get; set; }
}


public class LeaveTypeLookup
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("label")]
    public string? Label { get; set; }
}
