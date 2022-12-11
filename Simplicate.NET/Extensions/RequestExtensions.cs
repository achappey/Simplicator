
using Simplicate.NET.Models.Http;

namespace Simplicate.NET.Extensions;

public static class RequestExtensions
{

    public static Uri AddParameter(this Uri url, string paramName, string paramValue)
    {
        var uriBuilder = new UriBuilder(url);
        var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

        query[paramName] = paramValue;
        uriBuilder.Query = query.ToString();

        return uriBuilder.Uri;
    }

    public static async Task<IEnumerable<T>> PagedRequest<T>(this HttpClient client, Uri uri, string key, string secret, int delay = 1500)
    {
        List<T> items = new List<T>();

        uri = uri.AddParameter("metadata", "offset,count,limit");

        int offset = 0;

        SimplicateCollectionResponse<T>? result = null;

        do
        {
            uri = uri.AddParameter("offset", offset.ToString());

            result = await client.SimplicateGetRequest<SimplicateCollectionResponse<T>>(uri, key, secret);

            if (result != null)
            {
                items.AddRange(result.Data);

                offset = result.Metadata!.Offset + result.Metadata.Limit;
            }

            System.Threading.Thread.Sleep(delay);
        }
        while (result?.Metadata!.Count > offset);

        return items;

    }

    private static async Task<T?> SimplicateRequest<T>(this HttpClient client, Uri uri, string key, string secret, HttpMethod method, object? bodyContent = null)
    {     
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = method,
            RequestUri = uri,
            Headers = {
            { System.Net.HttpRequestHeader.Accept.ToString(), "application/json" },
            { System.Net.HttpRequestHeader.ContentType.ToString(), "application/json" },
            { "Authentication-Key", key },
            { "Authentication-Secret", secret }
        },
            Content = bodyContent != null ? JsonContent.Create(bodyContent) : null
        };

        var result = await client.SendAsync(httpRequestMessage);

        return await result.HandleSimplicateResponse<T>();
    }

    private static async Task<T?> HandleSimplicateResponse<T>(this HttpResponseMessage message)
    {
        switch (message.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                if (message != null && message.Content != null)
                {
                    return await message.Content.ReadFromJsonAsync<T>();
                }

                return default(T);
            case System.Net.HttpStatusCode.BadRequest:
                if (message != null && message.Content != null)
                {
                    var errors = await message.Content.ReadFromJsonAsync<SimplicateErrorResponse>();

                    if (errors != null && errors.Errors != null)
                    {
                        throw new SimplicateResponseException((int)message.StatusCode, string.Join(',', errors.Errors.Select(y => y.Message)));
                    }
                }
                break;
            case System.Net.HttpStatusCode.NotFound:
            case System.Net.HttpStatusCode.Unauthorized:
            default:
                break;
        }

        if (message != null)
            throw new SimplicateResponseException((int)message.StatusCode);
        else
            throw new SimplicateResponseException((int)System.Net.HttpStatusCode.InternalServerError);
    }

    private static async Task<T> SimplicateItemRequest<T>(this HttpClient client, Uri uri, string key, string secret, object bodyContent, HttpMethod method)
    {
        var result = await client.SimplicateRequest<SimplicateItemResponse<T>>(uri, key, secret, method, bodyContent);

        if (result != null && result.Data != null)
        {
            return result.Data;
        }

        if (result != null && result.Errors != null)
        {
            throw new Exception(string.Join(',', result.Errors));
        }

        throw new Exception();
    }

    public static async Task<T> SimplicatePostRequest<T>(this HttpClient client, Uri uri, string key, string secret, object bodyContent)
    {
        return await client.SimplicateItemRequest<T>(uri, key, secret, bodyContent, HttpMethod.Post);
    }

    public static async Task<T> SimplicatePutRequest<T>(this HttpClient client, Uri uri, string key, string secret, object bodyContent)
    {
        return await client.SimplicateItemRequest<T>(uri, key, secret, bodyContent, HttpMethod.Put);
    }
    
    public static async Task<T?> SimplicateGetRequest<T>(this HttpClient client, Uri uri, string key, string secret)
    {
        return await client.SimplicateRequest<T>(uri, key, secret, HttpMethod.Get);
    }

}
