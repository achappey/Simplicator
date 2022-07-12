
using Simplicate.NET.Models.Http;
using System.Net.Http.Json;

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

    public static async Task<IEnumerable<T>> PagedRequest<T>(this HttpClient client, Uri uri, string key, string secret, int delay = 2000)
    {
        List<T> items = new List<T>();

        uri = uri.AddParameter("metadata", "offset,count,limit");

        int offset = 0;

        SimplicateResponse<T>? result = null;

        do
        {
            uri = uri.AddParameter("offset", offset.ToString());

            result = await client.SimplicateGetRequest<SimplicateResponse<T>>(uri, key, secret);

            if (result != null)
            {
                items.AddRange(result.Data);

                offset = result.Metadata.Offset + result.Metadata.Limit;
            }

            System.Threading.Thread.Sleep(delay);
        }
        while (result?.Metadata.Count > offset);

        return items;

    }

    public static async Task<T?> SimplicateRequest<T>(this HttpClient client, Uri uri, string key, string secret, HttpMethod method, string? bodyContent = null)
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
            Content = !string.IsNullOrEmpty(bodyContent) ? new StringContent(bodyContent) : null
        };

        var result = await client.SendAsync(httpRequestMessage);

        result.EnsureSuccessStatusCode();

        if (result != null && result.Content != null)
        {
            return await result.Content.ReadFromJsonAsync<T>();
        }

        return default(T);
    }

    public static async Task<T?> SimplicatePostRequest<T>(this HttpClient client, Uri uri, string key, string secret, string bodyContent)
    {
        return await client.SimplicateRequest<T>(uri, key, secret, HttpMethod.Post, bodyContent);
    }

    public static async Task<T?> SimplicateGetRequest<T>(this HttpClient client, Uri uri, string key, string secret)
    {
        return await client.SimplicateRequest<T>(uri, key, secret, HttpMethod.Get);
    }

}
