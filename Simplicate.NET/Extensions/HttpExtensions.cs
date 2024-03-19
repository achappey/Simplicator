
using System.Text;
using Simplicate.NET.Models;
using Simplicate.NET.Models.Http;

namespace Simplicate.NET.Extensions;

public static class HttpExtensions
{

    public static async Task<IEnumerable<Organization>> GetOrganizations(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Organization>(environment.BuildRequestUri(Endpoints.Crm.Organization), key, secret);
    }

    public static async Task<Organization?> GetOrganization(this HttpClient client, string environment, string key, string secret, string id)
    {
        var result = await client.SimplicateGetRequest<SimplicateItemResponse<Organization>>(environment.BuildRequestUri(Endpoints.Crm.Organization, id), key, secret);

        return result?.Data;
    }

    public static async Task<Sales?> GetSales(this HttpClient client, string environment, string key, string secret, string id)
    {
        var result = await client.SimplicateGetRequest<SimplicateItemResponse<Sales>>(environment.BuildRequestUri(Endpoints.SalesInfo.Sales, id), key, secret);

        return result?.Data;
    }

    public static async Task<Project?> GetProject(this HttpClient client, string environment, string key, string secret, string id)
    {
        var result = await client.SimplicateGetRequest<SimplicateItemResponse<Project>>(environment.BuildRequestUri(Endpoints.Projects.Project, id), key, secret);

        return result?.Data;
    }

    public static async Task<Quote?> GetQuote(this HttpClient client, string environment, string key, string secret, string id)
    {
        var result = await client.SimplicateGetRequest<SimplicateItemResponse<Quote>>(environment.BuildRequestUri(Endpoints.SalesInfo.Quote, id), key, secret);

        return result?.Data;
    }

    public static async Task<IEnumerable<MyOrganization>> GetMyOrganizations(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<MyOrganization>(environment.BuildRequestUri(Endpoints.Crm.MyOrganization), key, secret);
    }

    public static async Task<IEnumerable<Person>> GetPersons(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Person>(environment.BuildRequestUri(Endpoints.Crm.Person), key, secret);
    }

    public static async Task<IEnumerable<Employee>> GetEmployees(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Employee>(environment.BuildRequestUri(Endpoints.Hrm.Employee), key, secret);
    }

    public static async Task<IEnumerable<Sales>> GetSales(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Sales>(environment.BuildRequestUri(Endpoints.SalesInfo.Sales), key, secret);
    }

    public static async Task<IEnumerable<Quote>> GetQuotes(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Quote>(environment.BuildRequestUri(Endpoints.SalesInfo.Quote), key, secret);
    }

    public static async Task<IEnumerable<QuoteStatus>> GetQuoteStatuses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<QuoteStatus>(environment.BuildRequestUri(Endpoints.SalesInfo.QuoteStatus), key, secret);
    }

    public static async Task<IEnumerable<QuoteTemplate>> GetQuoteTemplates(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<QuoteTemplate>(environment.BuildRequestUri(Endpoints.SalesInfo.QuoteTemplate), key, secret);
    }

    public static async Task<IEnumerable<ProjectStatus>> GetProjectStatuses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<ProjectStatus>(environment.BuildRequestUri(Endpoints.Projects.ProjectStatus, null, "select=id,label,color"), key, secret);
    }

    public static async Task<IEnumerable<InvoiceStatus>> GetInvoiceStatuses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<InvoiceStatus>(environment.BuildRequestUri(Endpoints.Invoices.InvoiceStatus, null, "select=id,name,color"), key, secret);
    }

    public static async Task<IEnumerable<SalesStatus>> GetSalesStatuses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<SalesStatus>(environment.BuildRequestUri(Endpoints.SalesInfo.SalesStatus, null, "select=id,label"), key, secret);
    }

    public static async Task<IEnumerable<SalesSource>> GetSalesSources(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<SalesSource>(environment.BuildRequestUri(Endpoints.SalesInfo.SalesSource, null, "select=id,name"), key, secret);
    }

    public static async Task<IEnumerable<RevenueGroup>> GetRevenueGroups(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<RevenueGroup>(environment.BuildRequestUri(Endpoints.SalesInfo.RevenueGroup), key, secret);
    }

    public static async Task<IEnumerable<Industry>> GetIndustries(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Industry>(environment.BuildRequestUri(Endpoints.Crm.Industry), key, secret);
    }

    public static async Task<IEnumerable<SalesProgress>> GetSalesProgresses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<SalesProgress>(environment.BuildRequestUri(Endpoints.SalesInfo.SalesProgress), key, secret);
    }

    public static async Task<IEnumerable<VatClass>> GetVatClasses(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<VatClass>(environment.BuildRequestUri(Endpoints.Invoices.VatClass), key, secret);
    }

    public static async Task<IEnumerable<Invoice>> GetInvoices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Invoice>(environment.BuildRequestUri(Endpoints.Invoices.Invoice), key, secret);
    }


    public static async Task<IEnumerable<Project>> GetProjects(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Project>(environment.BuildRequestUri(Endpoints.Projects.Project), key, secret);
    }
    public static async Task<IEnumerable<ProjectServices>> GetProjectServices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<ProjectServices>(environment.BuildRequestUri(Endpoints.Projects.Service), key, secret);
    }

    public static async Task<IEnumerable<SalesService>> GetSalesServices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<SalesService>(environment.BuildRequestUri(Endpoints.SalesInfo.Service), key, secret);
    }

    public static async Task<string?> AddProjectService(this HttpClient client, string environment, string key, string secret, NewProjectService service)
    {
        var item = await client.SimplicatePostRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.Projects.Service),
            key, secret, service);

        return item?.Id;
    }

    public static async Task<string?> UpdateProjectService(this HttpClient client, string environment, string key, string secret, string id, ProjectService service)
    {
        var item = await client.SimplicatePutRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.Projects.Service, id),
            key, secret, service);

        return item?.Id;
    }

    public static async Task<IEnumerable<Hours>> GetProjectHours(this HttpClient client, string environment, string key, string secret, string projectId)
    {
        return await client.PagedRequest<Hours>(environment.BuildRequestUri(Endpoints.Hours.TimeEntry, null, string.Format("q[project.id]={0}", projectId)), key, secret);
    }

    public static async Task<IEnumerable<Invoice>> GetProjectInvoices(this HttpClient client, string environment, string key, string secret, string projectId)
    {
        return await client.PagedRequest<Invoice>(environment.BuildRequestUri(Endpoints.Invoices.Invoice, null, string.Format("q[projects.id]={0}", projectId)), key, secret);
    }

    public static async Task<IEnumerable<DefaultService>> GetDefaultServices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<DefaultService>(environment.BuildRequestUri(Endpoints.Services.DefaultService), key, secret);
    }

    /// <summary>
    /// Retrieves the hours data from the Simplicate API.
    /// </summary>
    /// <param name="client">The HttpClient instance to use for making the request.</param>
    /// <param name="environment">The environment to be used for the API request.</param>
    /// <param name="key">The authentication key for the API request.</param>
    /// <param name="secret">The authentication secret for the API request.</param>
    /// <returns>A Task representing the asynchronous operation, with a result of an IEnumerable of Hours objects.</returns>
    public static async Task<IEnumerable<Hours>> GetHours(this HttpClient client, string environment, string key, string secret)
    {
        string requestPath = Endpoints.Hours.TimeEntry;
        string selectQuery = @"select=id,employee.,projectservice.,
                           project.,invoice_status,start_date,
                           end_date,hours,status,
                           billable,tariff,note";
        Uri requestUri = environment.BuildRequestUri(requestPath, null, selectQuery);

        return await client.PagedRequest<Hours>(requestUri, key, secret, 500);
    }

    public static async Task<int> GetHourCount(this HttpClient client, string environment, string key, string secret)
    {
        string requestPath = Endpoints.Hours.TimeEntry;
        string selectQuery = @"select=id,employee.,projectservice.,
                           project.,invoice_status,start_date,
                           end_date,hours,status,
                           billable,tariff,note";
        //created_at,updated_at
        Uri requestUri = environment.BuildRequestUri(requestPath, null, selectQuery);

        return await client.GetTotalItemCount<Hours>(requestUri, key, secret);
    }

    public static async Task<IEnumerable<Hours>> GetHourPage(this HttpClient client, string environment, string key,
        string secret, int top, int skip)
    {
        string requestPath = Endpoints.Hours.TimeEntry;
        string selectQuery = @"select=id,employee.,projectservice.,
                           project.,invoice_status,start_date,
                           end_date,hours,status,
                           billable,tariff,note";
        //created_at,updated_at
        Uri requestUri = environment.BuildRequestUri(requestPath, null, selectQuery);

        return await client.GetItemsPerPage<Hours>(requestUri, key, secret, top, skip, 500);
    }

    public static async Task<IEnumerable<Hours>> GetHoursByYear(this HttpClient client, string environment, string key, string secret, int year)
    {
        string requestPath = Endpoints.Hours.TimeEntry;
        string startDate = $"{year}-01-01 00:00:00";
        string endDate = $"{year}-12-31 23:59:59";
        string selectQuery = $@"select=id,employee.,projectservice.,project.,invoice_status,start_date,end_date,hours,status,billable,tariff,note&q[start_date][le]={endDate}&q[start_date][ge]={startDate}";

        Uri requestUri = environment.BuildRequestUri(requestPath, null, selectQuery);
        return await client.PagedRequest<Hours>(requestUri, key, secret, 500);
    }

    public static async Task<int> GetHourCountByYear(this HttpClient client, string environment, string key, string secret, int year)
    {
        string requestPath = Endpoints.Hours.TimeEntry;
        string startDate = $"{year}-01-01 00:00:00";
        string endDate = $"{year}-12-31 23:59:59";
        string selectQuery = $@"select=id,employee.,projectservice.,project.,invoice_status,start_date,end_date,hours,status,billable,tariff,note&q[start_date][le]={endDate}&q[start_date][ge]={startDate}";

        Uri requestUri = environment.BuildRequestUri(requestPath, null, selectQuery);
        return await client.GetTotalItemCount<Hours>(requestUri, key, secret);
    }


    public static async Task<IEnumerable<Hours>> GetHourPageByYear(this HttpClient client, string environment, string key,
        string secret, int top, int skip, int year)
    {
        string requestPath = Endpoints.Hours.TimeEntry;
        string selectQuery = @"select=id,employee.,projectservice.,project.,invoice_status,start_date,end_date,hours,status,billable,tariff,note";

        string startDate = $"{year}-01-01 00:00:00";
        string endDate = $"{year}-12-31 23:59:59";

        string dateFilter = $"&q[start_date][le]={endDate}&q[start_date][ge]={startDate}";
        string requestQuery = selectQuery + dateFilter;
        //created_at,updated_at
        Uri requestUri = environment.BuildRequestUri(requestPath, null, requestQuery);

        return await client.GetItemsPerPage<Hours>(requestUri, key, secret, top, skip, 500);
    }

    /// <summary>
    /// Retrieves the leaves data from the Simplicate API.
    /// </summary>
    /// <param name="client">The HttpClient instance to use for making the request.</param>
    /// <param name="environment">The environment to be used for the API request.</param>
    /// <param name="key">The authentication key for the API request.</param>
    /// <param name="secret">The authentication secret for the API request.</param>
    /// <returns>A Task representing the asynchronous operation, with a result of an IEnumerable of Hours objects.</returns>
    public static async Task<IEnumerable<Leave>> GetLeaves(this HttpClient client, string environment, string key, string secret)
    {
        string requestPath = Endpoints.Hrm.Leave;
        string selectQuery = @"select=id,employee.,
                           start_date,end_date,description,
                           leavetype.,hours";

        Uri requestUri = environment.BuildRequestUri(requestPath, null, selectQuery);

        return await client.PagedRequest<Leave>(requestUri, key, secret);
    }

    /// <summary>
    /// Retrieves the timetables data from the Simplicate API.
    /// </summary>
    /// <param name="client">The HttpClient instance to use for making the request.</param>
    /// <param name="environment">The environment to be used for the API request.</param>
    /// <param name="key">The authentication key for the API request.</param>
    /// <param name="secret">The authentication secret for the API request.</param>
    /// <returns>A Task representing the asynchronous operation, with a result of an IEnumerable of Hours objects.</returns>
    public static async Task<IEnumerable<TimeTable>> GetTimeTables(this HttpClient client, string environment, string key, string secret)
    {
        string requestPath = Endpoints.Hrm.TimeTable;
        string selectQuery = @"select=id,even_week,employee.,
                           start_date,end_date,odd_week";

        Uri requestUri = environment.BuildRequestUri(requestPath, null, selectQuery);

        return await client.PagedRequest<TimeTable>(requestUri, key, secret);
    }

    public static async Task<IEnumerable<Hours>> GetEmployeeHours(this HttpClient client, string environment, string key, string secret, string employeeId)
    {
        return await client.PagedRequest<Hours>(environment.BuildRequestUri(Endpoints.Hours.TimeEntry, null, string.Format("q[employee.id]={0}", employeeId)), key, secret);
    }

    /// <summary>
    /// Builds a request URI for the Simplicate API based on the given environment, API request, ID, and query.
    /// </summary>
    /// <param name="environment">The environment to be used for the API request.</param>
    /// <param name="apiRequest">The API request path.</param>
    /// <param name="id">The optional ID to be included in the request path. Default value is null.</param>
    /// <param name="query">The optional query string to be appended to the request path. Default value is null.</param>
    /// <returns>A Uri representing the constructed request URI.</returns>
    public static Uri BuildRequestUri(this string environment, string apiRequest, string? id = null, string? query = null)
    {
        var baseUriBuilder = new StringBuilder()
            .Append(Endpoints.GetApiUrl(environment))
            .Append(apiRequest);

        if (!string.IsNullOrWhiteSpace(id))
        {
            baseUriBuilder.AppendFormat("/{0}", id);
        }

        if (!string.IsNullOrWhiteSpace(query))
        {
            baseUriBuilder.AppendFormat("?{0}", query);
        }

        return new Uri(baseUriBuilder.ToString());
    }

}
