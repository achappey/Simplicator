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

    public async Task<IEnumerable<DefaultService>> GetDefaultServices(string environment, string key, string secret)
    {
        return await this._client.GetDefaultServices(environment, key, secret);
    }

    public async Task<IEnumerable<VatClass>> GetVatClasses(string environment, string key, string secret)
    {
        return await this._client.GetVatClasses(environment, key, secret);
    }

    public async Task<IEnumerable<ProjectServices>> GetProjectServices(string environment, string key, string secret)
    {
        return await this._client.GetProjectServices(environment, key, secret);
    }

    public async Task<ProjectService> AddProjectService(string environment, string key, string secret, NewProjectService service)
    {
        service.Id = await this._client.AddProjectService(environment, key, secret, service);

        return service;
    }

    public async Task<ProjectService> UpdateProjectService(string environment, string key, string secret, string id, ProjectService service)
    {
        service.Id = await this._client.UpdateProjectService(environment, key, secret, id, service);

        return service;
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
 
    public async Task<IEnumerable<Hours>> GetProjectHours(string environment, string key, string secret, string projectId)
    {
        return await this._client.GetProjectHours(environment, key, secret, projectId);
    }

     public async Task<IEnumerable<Hours>> GetEmployeeHours(string environment, string key, string secret, string employeeId)
    {
        return await this._client.GetEmployeeHours(environment, key, secret, employeeId);
    }
}
