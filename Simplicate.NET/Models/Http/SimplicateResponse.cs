namespace Simplicate.NET.Models.Http;

public class SimplicateResponse<T>
{
    public Metadata Metadata { get; set; } = null!;
    public IEnumerable<T> Data { get; set; } = null!;

}