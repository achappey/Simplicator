
using Simplicate.NET.Models;
using System.Text.Json;

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

    public static async Task<IEnumerable<Project>> GetProjects(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Project>(environment.BuildRequestUri(Endpoints.PROJECT), key, secret);
    }

    public static async Task<IEnumerable<Sales>> GetSales(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Sales>(environment.BuildRequestUri(Endpoints.SALES), key, secret);
    }

    public static async Task<IEnumerable<RevenueGroup>> GetRevenueGroups(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<RevenueGroup>(environment.BuildRequestUri(Endpoints.REVENUEGROUP), key, secret);
    }

    public static async Task<IEnumerable<Service>> GetDefaultServices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Service>(environment.BuildRequestUri(Endpoints.DEFAULTSERVICE), key, secret);
    }

    public static async Task<IEnumerable<Invoice>> GetInvoices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Invoice>(environment.BuildRequestUri(Endpoints.INVOICE), key, secret);
    }

    public static async Task<IEnumerable<ProjectService>> GetProjectServices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<ProjectService>(environment.BuildRequestUri(Endpoints.PROJECTSERVICE), key, secret);
    }

    public static async Task<ProjectService?> AddProjectService(this HttpClient client, string environment, string key, string secret, ProjectService service)
    {
        return await client.SimplicatePostRequest<ProjectService>(
            environment.BuildRequestUri(Endpoints.PROJECTSERVICE), 
            key, secret, JsonSerializer.Serialize(service));
    }

    public static async Task<IEnumerable<Hours>> GetHours(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Hours>(environment.BuildRequestUri(Endpoints.HOURS), key, secret);
    }

    public static Uri BuildRequestUri(this string environment, string apiRequest)
    {
        return new Uri(string.Format("{0}{1}", string.Format(Endpoints.API_URL, environment), apiRequest));
    }

}
