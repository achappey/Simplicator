
using System.Diagnostics;
using System.Text;
using System.Text.Json;
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

    /// <summary>
    /// Sends paged HTTP GET requests to the specified URI and retrieves the response as a collection of objects of type T.
    /// </summary>
    /// <typeparam name="T">The type of objects in the response collection.</typeparam>
    /// <param name="client">The HttpClient instance used to send the request.</param>
    /// <param name="uri">The request URI.</param>
    /// <param name="key">The API key used for authentication.</param>
    /// <param name="secret">The API secret used for authentication.</param>
    /// <param name="delayMilliseconds">The delay between requests in milliseconds. Default value is 1500.</param>
    /// <returns>A task representing an IEnumerable of type T containing the response items.</returns>
    public static async Task<IEnumerable<T>> PagedRequest<T>(this HttpClient client, Uri uri, string key, string secret, int delayMilliseconds = 1000)
    {
        List<T> items = new List<T>();

        uri = uri.AddParameter("metadata", "offset,count,limit");

        int offset = 0;

        SimplicateCollectionResponse<T>? result = null;

        do
        {
            uri = uri.AddParameter("offset", offset.ToString());

            var stopwatch = Stopwatch.StartNew();
            result = await client.SimplicateGetRequest<SimplicateCollectionResponse<T>>(uri, key, secret);

            if (result != null)
            {
                items.AddRange(result.Data);

                offset = result.Metadata!.Offset + result.Metadata.Limit;
            }

            int timeOut = CalculateTimeout(delayMilliseconds, stopwatch.ElapsedMilliseconds);

            await Task.Delay(timeOut);
        }
        while (result?.Metadata!.Count > offset);

        return items;
    }

    private static int CalculateTimeout(int delayMilliseconds, long elapsedMilliseconds)
    {
        int timeOut = delayMilliseconds - (int)elapsedMilliseconds;
        return timeOut < 0 ? 0 : timeOut;
    }

    /// <summary>
    /// Sends an HTTP request with the specified method to the given URI, including the provided API key and secret for authentication.
    /// </summary>
    /// <typeparam name="T">The type of the response object.</typeparam>
    /// <param name="client">The HttpClient instance used to send the request.</param>
    /// <param name="uri">The request URI.</param>
    /// <param name="key">The API key used for authentication.</param>
    /// <param name="secret">The API secret used for authentication.</param>
    /// <param name="method">The HTTP method to be used in the request.</param>
    /// <param name="bodyContent">The content of the request body, if any. Default value is null.</param>
    /// <returns>A task representing the response object of type T.</returns>
    private static async Task<T?> SimplicateRequest<T>(this HttpClient client, Uri uri, string key, string secret, HttpMethod method, object? bodyContent = null)
    {
        using (var httpRequestMessage = new HttpRequestMessage
        {
            Method = method,
            RequestUri = uri,
            Content = bodyContent != null ? new StringContent(JsonSerializer.Serialize(bodyContent), Encoding.UTF8, "application/json") : null
        })
        {
            SetAuthenticationHeaders(httpRequestMessage, key, secret);

            using (var result = await client.SendAsync(httpRequestMessage))
            {
                return await result.HandleSimplicateResponse<T>();
            }
        }
    }

    private static void SetAuthenticationHeaders(HttpRequestMessage httpRequestMessage, string key, string secret)
    {
        httpRequestMessage.Headers.Add("Authentication-Key", key);
        httpRequestMessage.Headers.Add("Authentication-Secret", secret);
    }

    /// <summary>
    /// Handles the Simplicate API response and returns the deserialized object of type T or throws an appropriate exception.
    /// </summary>
    /// <typeparam name="T">The type of the response object.</typeparam>
    /// <param name="message">The HttpResponseMessage to be handled.</param>
    /// <returns>A task representing the response object of type T, or null if the response content is null.</returns>
    private static async Task<T?> HandleSimplicateResponse<T>(this HttpResponseMessage message)
    {
        switch (message.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                if (message.Content != null)
                {
                    return await message.Content.ReadFromJsonAsync<T>();
                }

                return default(T);
            case System.Net.HttpStatusCode.BadRequest:
                if (message.Content != null)
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

        throw new SimplicateResponseException((int)message.StatusCode);
    }

    /// <summary>
    /// Sends an HTTP request with the specified method to the given URI, including the provided API key and secret for authentication, and retrieves an item of type T.
    /// </summary>
    /// <typeparam name="T">The type of the response object.</typeparam>
    /// <param name="client">The HttpClient instance used to send the request.</param>
    /// <param name="uri">The request URI.</param>
    /// <param name="key">The API key used for authentication.</param>
    /// <param name="secret">The API secret used for authentication.</param>
    /// <param name="bodyContent">The content of the request body.</param>
    /// <param name="method">The HTTP method to be used in the request.</param>
    /// <returns>A task representing the response object of type T.</returns>
    private static async Task<T> SimplicateItemRequest<T>(this HttpClient client, Uri uri, string key, string secret, object bodyContent, HttpMethod method)
    {
        var result = await client.SimplicateRequest<SimplicateItemResponse<T>>(uri, key, secret, method, bodyContent);

        if (result != null)
        {
            if (result.Data != null)
            {
                return result.Data;
            }

            if (result.Errors != null)
            {
                throw new InvalidOperationException(string.Join(',', result.Errors));
            }
        }

        return default(T);
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
