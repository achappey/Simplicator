using Simplicate.NET.Models;
using Simplicate.NET.Extensions;

namespace Simplicate.NET;

public class SimplicateClient
{
    private readonly HttpClient _httpClient = null!;

    public SimplicateClient(HttpClient client)
    {
        _httpClient = client;
    }

    public async Task<IEnumerable<Person>> GetPersons(string environment, string key, string secret)
    {
        return await this._httpClient.GetPersons(environment, key, secret);
    }

    public async Task<IEnumerable<Organization>> GetOrganizations(string environment, string key, string secret)
    {
        return await this._httpClient.GetOrganizations(environment, key, secret);
    }

    public async Task<IEnumerable<Project>> GetProjects(string environment, string key, string secret)
    {
        return await this._httpClient.GetProjects(environment, key, secret);
    }

    public async Task<IEnumerable<Sales>> GetSales(string environment, string key, string secret)
    {
        return await this._httpClient.GetSales(environment, key, secret);
    }

    public async Task<IEnumerable<RevenueGroup>> GetRevenueGroups(string environment, string key, string secret)
    {
        return await this._httpClient.GetRevenueGroups(environment, key, secret);
    }

    public async Task<IEnumerable<Service>> GetDefaultServices(string environment, string key, string secret)
    {
        return await this._httpClient.GetDefaultServices(environment, key, secret);
    }

    public async Task<IEnumerable<Employee>> GetEmployees(string environment, string key, string secret)
    {
        return await this._httpClient.GetEmployees(environment, key, secret);
    }

    public async Task<IEnumerable<Invoice>> GetInvoices(string environment, string key, string secret)
    {
        return await this._httpClient.GetInvoices(environment, key, secret);
    }

    public async Task<IEnumerable<ProjectService>> GetProjectServices(string environment, string key, string secret)
    {
        return await this._httpClient.GetProjectServices(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetHours(string environment, string key, string secret)
    {
        return await this._httpClient.GetHours(environment, key, secret);
    }

    public async Task<ProjectService> AddProjectService(string environment, string key, string secret, ProjectService service)
    {
        var item = await this._httpClient.AddProjectService(environment, key, secret, service);

        return item != null ? item : throw new Exception();
    }


}
