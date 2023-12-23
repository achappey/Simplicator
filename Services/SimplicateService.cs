using Simplicate.NET;
using Simplicate.NET.Models;

namespace Simplicator.Services;

public sealed class SimplicateService
{
    private readonly SimplicateClient _client;

    public SimplicateService(
        SimplicateClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Project>> GetProjects(string environment, string key, string secret)
    {
        return await _client.GetProjects(environment, key, secret);
    }

    public async Task<IEnumerable<Sales>> GetSales(string environment, string key, string secret)
    {
        return await _client.GetSales(environment, key, secret);
    }

    public async Task<IEnumerable<Quote>> GetQuotes(string environment, string key, string secret)
    {
        return await _client.GetQuotes(environment, key, secret);
    }

    public async Task<IEnumerable<QuoteStatus>> GetQuoteStatuses(string environment, string key, string secret)
    {
        return await _client.GetQuoteStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<Industry>> GetIndustries(string environment, string key, string secret)
    {
        return await _client.GetIndustries(environment, key, secret);
    }

    public async Task<IEnumerable<QuoteTemplate>> GetQuoteTemplates(string environment, string key, string secret)
    {
        return await _client.GetQuoteTemplates(environment, key, secret);
    }

    public async Task<IEnumerable<ProjectStatus>> GetProjectStatuses(string environment, string key, string secret)
    {
        return await _client.GetProjectStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<InvoiceStatus>> GetInvoiceStatuses(string environment, string key, string secret)
    {
        return await _client.GetInvoiceStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<SalesStatus>> GetSalesStatuses(string environment, string key, string secret)
    {
        return await _client.GetSalesStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<SalesSource>> GetSalesSources(string environment, string key, string secret)
    {
        return await _client.GetSalesSources(environment, key, secret);
    }
    public async Task<IEnumerable<SalesProgress>> GetSalesProgresses(string environment, string key, string secret)
    {
        return await _client.GetSalesProgresses(environment, key, secret);
    }

    public async Task<IEnumerable<Person>> GetPersons(string environment, string key, string secret)
    {
        return await _client.GetPersons(environment, key, secret);
    }

    public async Task<IEnumerable<Organization>> GetOrganizations(string environment, string key, string secret)
    {
        return await _client.GetOrganizations(environment, key, secret);
    }

    public async Task<Organization?> GetOrganization(string environment, string key, string secret, string id)
    {
        return await _client.GetOrganization(environment, key, secret, id);
    }

    public async Task<Sales?> GetSales(string environment, string key, string secret, string id)
    {
        return await _client.GetSales(environment, key, secret, id);
    }

    public async Task<Project?> GetProject(string environment, string key, string secret, string id)
    {
        return await _client.GetProject(environment, key, secret, id);
    }


    public async Task<Quote?> GetQuote(string environment, string key, string secret, string id)
    {
        return await _client.GetQuote(environment, key, secret, id);
    }

    public async Task<IEnumerable<MyOrganization>> GetMyOrganizations(string environment, string key, string secret)
    {
        return await _client.GetMyOrganizations(environment, key, secret);
    }

    public async Task<IEnumerable<RevenueGroup>> GetRevenueGroups(string environment, string key, string secret)
    {
        return await _client.GetRevenueGroups(environment, key, secret);
    }

    public async Task<IEnumerable<DefaultService>> GetDefaultServices(string environment, string key, string secret)
    {
        return await _client.GetDefaultServices(environment, key, secret);
    }

    public async Task<IEnumerable<VatClass>> GetVatClasses(string environment, string key, string secret)
    {
        return await _client.GetVatClasses(environment, key, secret);
    }

    public async Task<IEnumerable<ProjectServices>> GetProjectServices(string environment, string key, string secret)
    {
        return await _client.GetProjectServices(environment, key, secret);
    }

    public async Task<IEnumerable<SalesService>> GetSalesServices(string environment, string key, string secret)
    {
        return await _client.GetSalesServices(environment, key, secret);
    }

    public async Task<ProjectService> AddProjectService(string environment, string key, string secret, NewProjectService service)
    {
        service.Id = await _client.AddProjectService(environment, key, secret, service);

        return service;
    }


    public async Task<ProjectService> UpdateProjectService(string environment, string key, string secret, string id, ProjectService service)
    {
        service.Id = await _client.UpdateProjectService(environment, key, secret, id, service);

        return service;
    }

    public async Task<IEnumerable<Invoice>> GetInvoices(string environment, string key, string secret)
    {
        return await _client.GetInvoices(environment, key, secret);
    }

    public async Task<IEnumerable<Employee>> GetEmployees(string environment, string key, string secret)
    {
        return await _client.GetEmployees(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetHours(string environment, string key, string secret)
    {
        return await _client.GetHours(environment, key, secret);
    }

    public async Task<int> GetHoursCount(string environment, string key, string secret)
    {
        return await _client.GetHourPageCount(environment, key, secret);
    }

    public async Task<int> GetHourCount(string environment, string key, string secret)
    {
        return await _client.GetHourPageCount(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetHourPage(string environment, string key, string secret, int top = 100, int skip = 0)
    {
        return await _client.GetHourPage(environment, key, secret, top, skip);
    }

    public async Task<IEnumerable<Leave>> GetLeaves(string environment, string key, string secret)
    {
        return await _client.GetLeaves(environment, key, secret);
    }

    public async Task<IEnumerable<TimeTable>> GetTimeTables(string environment, string key, string secret)
    {
        return await _client.GetTimeTables(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetProjectHours(string environment, string key, string secret, string projectId)
    {
        return await _client.GetProjectHours(environment, key, secret, projectId);
    }

    public async Task<IEnumerable<Invoice>> GetProjectInvoices(string environment, string key, string secret, string projectId)
    {
        return await _client.GetProjectInvoices(environment, key, secret, projectId);
    }

    public async Task<IEnumerable<Hours>> GetEmployeeHours(string environment, string key, string secret, string employeeId)
    {
        return await _client.GetEmployeeHours(environment, key, secret, employeeId);
    }
}
