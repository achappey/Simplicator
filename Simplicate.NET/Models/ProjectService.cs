using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class ProjectService : Service
{
    [JsonPropertyName("project_id")]
    public string ProjectId { get; set; } = null!;

    public IEnumerable<Installment>? Installments { get; set; }

}