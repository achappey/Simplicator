using System.Text.Json.Serialization;

namespace Simplicator.Models;

public class User
{
    public string Environment { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Secret { get; set; } = null!;
}



public class UserClaim
{
    [JsonPropertyName("user_id")]
    public string UserId { get; set; } = null!;
}
