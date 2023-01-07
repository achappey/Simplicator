
using Simplicate.NET.Models;
using Simplicate.NET.Models.Http;

namespace Simplicate.NET.Extensions;

public static class HttpExtensions
{

    public static async Task<IEnumerable<Organization>> GetOrganizations(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Organization>(environment.BuildRequestUri(Endpoints.ORGANIZATION), key, secret);
    }

    public static async Task<Organization?> GetOrganization(this HttpClient client, string environment, string key, string secret, string id)
    {
        var result = await client.SimplicateGetRequest<SimplicateItemResponse<Organization>>(environment.BuildRequestUri(Endpoints.ORGANIZATION, id), key, secret);

        return result?.Data;
    }

    public static async Task<Sales?> GetSales(this HttpClient client, string environment, string key, string secret, string id)
    {
        var result = await client.SimplicateGetRequest<SimplicateItemResponse<Sales>>(environment.BuildRequestUri(Endpoints.SALES, id), key, secret);

        return result?.Data;
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
        return await client.PagedRequest<Sales>(environment.BuildRequestUri(Endpoints.SALES, null, @"select=id,simplicate_url,created_at,updated_at,
        subject,note,chance_to_score,expected_revenue,organization.,
        my_organization_profile_id,status.,start_date,expected_closing_date,
        timeline_email_address,responsible_employee.,source.,
        linked_project.,progress."), key, secret);
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
        return await client.PagedRequest<ProjectStatus>(environment.BuildRequestUri(Endpoints.PROJECTSTATUS, null, "select=id,label,color"), key, secret);
    }

    public static async Task<IEnumerable<InvoiceStatus>> GetInvoiceStatuses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<InvoiceStatus>(environment.BuildRequestUri(Endpoints.INVOICESTATUS, null, "select=id,name,color"), key, secret);
    }

    public static async Task<IEnumerable<SalesStatus>> GetSalesStatuses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<SalesStatus>(environment.BuildRequestUri(Endpoints.SALESSTATUS, null, "select=id,label"), key, secret);
    }

    public static async Task<IEnumerable<SalesSource>> GetSalesSources(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<SalesSource>(environment.BuildRequestUri(Endpoints.SALESSOURCE, null, "select=id,name"), key, secret);
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
        return await client.PagedRequest<MessageType>(environment.BuildRequestUri(Endpoints.MESSAGETYPES, null, "select=id,label,blocked"), key, secret);
    }

    public static async Task<IEnumerable<DocumentType>> GetDocumentTypes(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<DocumentType>(environment.BuildRequestUri(Endpoints.DOCUMENTTYPES, null, "select=id,label"), key, secret);
    }

    public static async Task<IEnumerable<Document>> GetDocuments(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Document>(environment.BuildRequestUri(Endpoints.DOCUMENTS), key, secret);
    }

    public static async Task<IEnumerable<DefaultService>> GetDefaultServices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<DefaultService>(environment.BuildRequestUri(Endpoints.DEFAULTSERVICE), key, secret);
    }

    public static async Task<IEnumerable<Hours>> GetHours(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Hours>(environment.BuildRequestUri(Endpoints.HOURS, null, @"select=id,employee.,projectservice.,
        project.,invoice_status,start_date,end_date,hours,
        billable,status,billable,tariff"), key, secret);
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
