namespace Simplicate.NET.Models.Http;

public class SimplicateCollectionResponse<T>
{
    public Metadata? Metadata { get; set; }

    public IEnumerable<T> Data { get; set; } = null!;

    public IEnumerable<string>? Errors { get; set; }

}

public class SimplicateItemResponse<T>
{
    public T Data { get; set; } = default(T)!;

    public IEnumerable<string>? Errors { get; set; }
}

public class SimplicateCreateResponse
{
    public NewResource Data { get; set; } = null!;

    public IEnumerable<string>? Errors { get; set; }
}

public class SimplicateErrorResponse
{
    public IEnumerable<SimplicateError>? Errors { get; set; }
}

public class NewResource
{
    public string Id { get; set; } = null!;
}


public class SimplicateError
{
    public string Message { get; set; } = null!;
}

public class SimplicateResponseException : Exception
{
    public SimplicateResponseException(int statusCode, object? value = null) =>
        (StatusCode, Value) = (statusCode, value);

    public int StatusCode { get; }

    public object? Value { get; }
}
