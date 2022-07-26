
using Simplicate.NET.Models;

namespace Simplicate.NET.Extensions;

public static class HttpExtensions
{

    public static async Task<IEnumerable<Organization>> GetOrganizations(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Organization>(environment.BuildRequestUri(Endpoints.ORGANIZATION), key, secret);
    }

    public static async Task<IEnumerable<Person>> GetPersons(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Person>(environment.BuildRequestUri(Endpoints.PERSON), key, secret);
    }

    public static async Task<IEnumerable<Employee>> GetEmployees(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Employee>(environment.BuildRequestUri(Endpoints.EMPLOYEE), key, secret);
    }

    public static async Task<IEnumerable<Sales>> GetSales(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Sales>(environment.BuildRequestUri(Endpoints.SALES), key, secret);
    }

    public static async Task<IEnumerable<RevenueGroup>> GetRevenueGroups(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<RevenueGroup>(environment.BuildRequestUri(Endpoints.REVENUEGROUP), key, secret);
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
