namespace Simplicator.Models;

public class User
{
    public string? Name { get; set; }

    public string Environment { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Secret { get; set; } = null!;
}
