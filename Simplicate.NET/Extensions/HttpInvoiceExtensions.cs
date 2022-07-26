
using Simplicate.NET.Models;

namespace Simplicate.NET.Extensions;

public static class HttpInvoiceExtensions
{

    public static async Task<IEnumerable<VatClass>> GetVatClasses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<VatClass>(environment.BuildRequestUri(Endpoints.VATCLASS), key, secret);
    }

    public static async Task<IEnumerable<Invoice>> GetInvoices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Invoice>(environment.BuildRequestUri(Endpoints.INVOICE), key, secret);
    }


}
