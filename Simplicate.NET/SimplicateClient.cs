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

    public async Task<IEnumerable<Quote>> GetQuotes(string environment, string key, string secret)
    {
        return await this._httpClient.GetQuotes(environment, key, secret);
    }

    public async Task<IEnumerable<LabelLookup>> GetRevenueGroups(string environment, string key, string secret)
    {
        return await this._httpClient.GetRevenueGroups(environment, key, secret);
    }

    public async Task<IEnumerable<DefaultService>> GetDefaultServices(string environment, string key, string secret)
    {
        return await this._httpClient.GetDefaultServices(environment, key, secret);
    }

    public async Task<IEnumerable<VatClass>> GetVatClasses(string environment, string key, string secret)
    {
        return await this._httpClient.GetVatClasses(environment, key, secret);
    }

    public async Task<IEnumerable<Employee>> GetEmployees(string environment, string key, string secret)
    {
        return await this._httpClient.GetEmployees(environment, key, secret);
    }

    public async Task<IEnumerable<Contract>> GetContracts(string environment, string key, string secret)
    {
        return await this._httpClient.GetContracts(environment, key, secret);
    }

    public async Task<IEnumerable<Message>> GetMessages(string environment, string key, string secret)
    {
        return await this._httpClient.GetMessages(environment, key, secret);
    }

    public async Task<IEnumerable<Invoice>> GetInvoices(string environment, string key, string secret)
    {
        return await this._httpClient.GetInvoices(environment, key, secret);
    }

    public async Task<IEnumerable<ProjectServices>> GetProjectServices(string environment, string key, string secret)
    {
        return await this._httpClient.GetProjectServices(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetHours(string environment, string key, string secret)
    {
        return await this._httpClient.GetHours(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetProjectHours(string environment, string key, string secret, string projectId)
    {
        return await this._httpClient.GetProjectHours(environment, key, secret, projectId);
    }

    public async Task<IEnumerable<Hours>> GetEmployeeHours(string environment, string key, string secret, string employeeId)
    {
        return await this._httpClient.GetEmployeeHours(environment, key, secret, employeeId);
    }

    public async Task<string?> AddProjectService(string environment, string key, string secret, NewProjectService service)
    {
        return await this._httpClient.AddProjectService(environment, key, secret, service);
    }

    public async Task<string?> AddMessage(string environment, string key, string secret, NewMessage message)
    {
        return await this._httpClient.AddMessage(environment, key, secret, message);
    }

 public async Task<string?> AddInvoice(string environment, string key, string secret, NewInvoice invoice)
    {
        return await this._httpClient.AddInvoice(environment, key, secret, invoice);
    }

    public async Task<string?> UpdateProjectService(string environment, string key, string secret, string id, ProjectService service)
    {
        return await this._httpClient.UpdateProjectService(environment, key, secret, id, service);
    }
}
