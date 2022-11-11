
using Simplicate.NET.Models;

namespace Simplicate.NET.Extensions;

public static class HttpExtensions
{

    public static async Task<IEnumerable<Organization>> GetOrganizations(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Organization>(environment.BuildRequestUri(Endpoints.ORGANIZATION), key, secret);
    }

    public static async Task<IEnumerable<MyOrganization>> GetMyOrganizations(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<MyOrganization>(environment.BuildRequestUri(Endpoints.MYORGANIZATION), key, secret);
    }

    public static async Task<IEnumerable<Person>> GetPersons(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Person>(environment.BuildRequestUri(Endpoints.PERSON), key, secret);
    }

    public static async Task<IEnumerable<Employee>> GetEmployees(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Employee>(environment.BuildRequestUri(Endpoints.EMPLOYEE), key, secret);
    }

    public static async Task<IEnumerable<Contract>> GetContracts(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Contract>(environment.BuildRequestUri(Endpoints.CONTRACT), key, secret);
    }

 public static async Task<IEnumerable<Message>> GetMessages(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Message>(environment.BuildRequestUri(Endpoints.MESSAGE), key, secret);
    }

    public static async Task<IEnumerable<Sales>> GetSales(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Sales>(environment.BuildRequestUri(Endpoints.SALES), key, secret);
    }

    public static async Task<IEnumerable<Quote>> GetQuotes(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Quote>(environment.BuildRequestUri(Endpoints.QUOTES), key, secret);
    }

    public static async Task<IEnumerable<QuoteStatus>> GetQuoteStatuses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<QuoteStatus>(environment.BuildRequestUri(Endpoints.QUOTESTATUS), key, secret);
    }

public static async Task<IEnumerable<QuoteTemplate>> GetQuoteTemplates(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<QuoteTemplate>(environment.BuildRequestUri(Endpoints.QUOTETEMPLATE), key, secret);
    }

    public static async Task<IEnumerable<ProjectStatus>> GetProjectStatuses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<ProjectStatus>(environment.BuildRequestUri(Endpoints.PROJECTSTATUS), key, secret);
    }

    
    public static async Task<IEnumerable<InvoiceStatus>> GetInvoiceStatuses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<InvoiceStatus>(environment.BuildRequestUri(Endpoints.INVOICESTATUS), key, secret);
    }

    public static async Task<IEnumerable<SalesStatus>> GetSalesStatuses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<SalesStatus>(environment.BuildRequestUri(Endpoints.SALESSTATUS), key, secret);
    }

    public static async Task<IEnumerable<RevenueGroup>> GetRevenueGroups(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<RevenueGroup>(environment.BuildRequestUri(Endpoints.REVENUEGROUP), key, secret);
    }

    public static async Task<IEnumerable<Industry>> GetIndustries(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Industry>(environment.BuildRequestUri(Endpoints.CRMINDUSTRY), key, secret);
    }

    public static async Task<IEnumerable<SalesProgress>> GetSalesProgresses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<SalesProgress>(environment.BuildRequestUri(Endpoints.SALESPROGRESS), key, secret);
    }

    public static async Task<IEnumerable<MessageType>> GetMessageTypes(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<MessageType>(environment.BuildRequestUri(Endpoints.MESSAGETYPES), key, secret);
    }

    public static async Task<IEnumerable<DefaultService>> GetDefaultServices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<DefaultService>(environment.BuildRequestUri(Endpoints.DEFAULTSERVICE), key, secret);
    }

    public static async Task<IEnumerable<Hours>> GetHours(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Hours>(environment.BuildRequestUri(Endpoints.HOURS), key, secret);
    }

    public static async Task<IEnumerable<Hours>> GetEmployeeHours(this HttpClient client, string environment, string key, string secret, string employeeId)
    {
        return await client.PagedRequest<Hours>(environment.BuildRequestUri(Endpoints.HOURS, null, string.Format("q[employee.id]={0}", employeeId)), key, secret);
    }

    public static Uri BuildRequestUri(this string environment, string apiRequest, string? id = null, string? query = null)
    {
        var baseUri = string.Format("{0}{1}{2}{3}",
            string.Format(Endpoints.API_URL, environment),
            apiRequest,
            !string.IsNullOrEmpty(id) ? string.Format("/{0}", id) : "",
            !string.IsNullOrEmpty(query) ? string.Format("?{0}", query) : "");

        return new Uri(baseUri);
    }

}
