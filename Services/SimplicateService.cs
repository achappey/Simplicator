using Simplicate.NET;
using Simplicate.NET.Models;

namespace Simplicator.Services;

public class SimplicateService
{
    private readonly SimplicateClient _client;

    public SimplicateService(
        HttpClient client)
    {
        _client = new SimplicateClient(client);
    }

    public async Task<IEnumerable<Project>> GetProjects(string environment, string key, string secret)
    {
        return await this._client.GetProjects(environment, key, secret);
    }

    public async Task<IEnumerable<Sales>> GetSales(string environment, string key, string secret)
    {
        return await this._client.GetSales(environment, key, secret);
    }

    public async Task<IEnumerable<Person>> GetPersons(string environment, string key, string secret)
    {
        return await this._client.GetPersons(environment, key, secret);
    }

    public async Task<IEnumerable<Organization>> GetOrganizations(string environment, string key, string secret)
    {
        return await this._client.GetOrganizations(environment, key, secret);
    }
    
    public async Task<IEnumerable<RevenueGroup>> GetRevenueGroups(string environment, string key, string secret)
    {
        return await this._client.GetRevenueGroups(environment, key, secret);
    }

    public async Task<IEnumerable<ProjectService>> GetProjectServices(string environment, string key, string secret)
    {
        return await this._client.GetProjectServices(environment, key, secret);
    }

    public async Task<ProjectService> AddProjectService(string environment, string key, string secret, ProjectService service)
    {
        return await this._client.AddProjectService(environment, key, secret, service);
    }

    public async Task<IEnumerable<Invoice>> GetInvoices(string environment, string key, string secret)
    {
        return await this._client.GetInvoices(environment, key, secret);
    }

    public async Task<IEnumerable<Employee>> GetEmployees(string environment, string key, string secret)
    {
        return await this._client.GetEmployees(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetHours(string environment, string key, string secret)
    {
        return await this._client.GetHours(environment, key, secret);
    }

}
