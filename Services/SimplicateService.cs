using Simplicate.NET;
using Simplicate.NET.Models;

namespace Simplicator.Services;

public sealed class SimplicateService(
    SimplicateClient client)
{
    private readonly SimplicateClient _client = client;

    public Task<IEnumerable<Project>> GetProjects(string environment, string key, string secret)
    {
        return _client.GetProjects(environment, key, secret);
    }

    public Task<IEnumerable<Sales>> GetSales(string environment, string key, string secret)
    {
        return _client.GetSales(environment, key, secret);
    }

    public Task<IEnumerable<Quote>> GetQuotes(string environment, string key, string secret)
    {
        return _client.GetQuotes(environment, key, secret);
    }

    public Task<IEnumerable<QuoteStatus>> GetQuoteStatuses(string environment, string key, string secret)
    {
        return _client.GetQuoteStatuses(environment, key, secret);
    }

    public Task<IEnumerable<Industry>> GetIndustries(string environment, string key, string secret)
    {
        return _client.GetIndustries(environment, key, secret);
    }

    public Task<IEnumerable<QuoteTemplate>> GetQuoteTemplates(string environment, string key, string secret)
    {
        return _client.GetQuoteTemplates(environment, key, secret);
    }

    public Task<IEnumerable<ProjectStatus>> GetProjectStatuses(string environment, string key, string secret)
    {
        return _client.GetProjectStatuses(environment, key, secret);
    }

    public Task<IEnumerable<InvoiceStatus>> GetInvoiceStatuses(string environment, string key, string secret)
    {
        return _client.GetInvoiceStatuses(environment, key, secret);
    }

    public Task<IEnumerable<SalesStatus>> GetSalesStatuses(string environment, string key, string secret)
    {
        return _client.GetSalesStatuses(environment, key, secret);
    }

    public Task<IEnumerable<SalesSource>> GetSalesSources(string environment, string key, string secret)
    {
        return _client.GetSalesSources(environment, key, secret);
    }
    public Task<IEnumerable<SalesProgress>> GetSalesProgresses(string environment, string key, string secret)
    {
        return _client.GetSalesProgresses(environment, key, secret);
    }

    public Task<IEnumerable<Interest>> GetInterests(string environment, string key, string secret)
    {
        return _client.GetInterests(environment, key, secret);
    }

    public Task<IEnumerable<Person>> GetPersons(string environment, string key, string secret)
    {
        return _client.GetPersons(environment, key, secret);
    }

    public Task<IEnumerable<Organization>> GetOrganizations(string environment, string key, string secret)
    {
        return _client.GetOrganizations(environment, key, secret);
    }

    public Task<Organization?> GetOrganization(string environment, string key, string secret, string id)
    {
        return _client.GetOrganization(environment, key, secret, id);
    }

    public Task<Sales?> GetSales(string environment, string key, string secret, string id)
    {
        return _client.GetSales(environment, key, secret, id);
    }

    public Task<Project?> GetProject(string environment, string key, string secret, string id)
    {
        return _client.GetProject(environment, key, secret, id);
    }


    public Task<Quote?> GetQuote(string environment, string key, string secret, string id)
    {
        return _client.GetQuote(environment, key, secret, id);
    }

    public Task<IEnumerable<MyOrganization>> GetMyOrganizations(string environment, string key, string secret)
    {
        return _client.GetMyOrganizations(environment, key, secret);
    }

    public Task<IEnumerable<RevenueGroup>> GetRevenueGroups(string environment, string key, string secret)
    {
        return _client.GetRevenueGroups(environment, key, secret);
    }

    public Task<IEnumerable<DefaultService>> GetDefaultServices(string environment, string key, string secret)
    {
        return _client.GetDefaultServices(environment, key, secret);
    }

    public Task<IEnumerable<VatClass>> GetVatClasses(string environment, string key, string secret)
    {
        return _client.GetVatClasses(environment, key, secret);
    }

    public Task<IEnumerable<ProjectServices>> GetProjectServices(string environment, string key, string secret)
    {
        return _client.GetProjectServices(environment, key, secret);
    }

    public Task<IEnumerable<SalesService>> GetSalesServices(string environment, string key, string secret)
    {
        return _client.GetSalesServices(environment, key, secret);
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

    public Task<IEnumerable<Invoice>> GetInvoices(string environment, string key, string secret)
    {
        return _client.GetInvoices(environment, key, secret);
    }

    public Task<IEnumerable<Employee>> GetEmployees(string environment, string key, string secret)
    {
        return _client.GetEmployees(environment, key, secret);
    }

    public Task<IEnumerable<Contract>> GetContracts(string environment, string key, string secret)
    {
        return _client.GetContracts(environment, key, secret);
    }

    public Task<IEnumerable<Hours>> GetHours(string environment, string key, string secret)
    {
        return _client.GetHours(environment, key, secret);
    }

    public Task<IEnumerable<Hours>> GetHoursByYear(string environment, string key, string secret, int year)
    {
        return _client.GetHoursByYear(environment, key, secret, year);
    }

  public Task<IEnumerable<Hours>> GetHoursAfter(string environment, string key, string secret, DateTimeOffset dateTimeOffset)
    {
        return _client.GetHoursAfter(environment, key, secret, dateTimeOffset);
    }


    public Task<int> GetHourCount(string environment, string key, string secret)
    {
        return _client.GetHourPageCount(environment, key, secret);
    }

    public Task<int> GetHourPageCountAfter(string environment, string key, string secret, DateTimeOffset dateTimeOffset)
    {
        return _client.GetHourPageCountAfter(environment, key, secret, dateTimeOffset);
    }

    public Task<int> GetHourPageCountByYear(string environment, string key, string secret, int year)
    {
        return _client.GetHourPageCountByYear(environment, key, secret, year);
    }

    public Task<IEnumerable<Hours>> GetHourPage(string environment, string key, string secret, int top = 100, int skip = 0)
    {
        return _client.GetHourPage(environment, key, secret, top, skip);
    }

    public Task<IEnumerable<Hours>> GetHourPageAfter(string environment, string key, string secret, DateTimeOffset dateTimeOffset, int top = 100, int skip = 0)
    {
        return _client.GetHourPageAfter(environment, key, secret, top, skip, dateTimeOffset);
    }

    public Task<IEnumerable<Hours>> GetHourPageByYear(string environment, string key, string secret, int year, int top = 100, int skip = 0)
    {
        return _client.GetHourPageByYear(environment, key, secret, top, skip, year);
    }

    public Task<IEnumerable<Leave>> GetLeaves(string environment, string key, string secret)
    {
        return _client.GetLeaves(environment, key, secret);
    }

    public Task<IEnumerable<TimeTable>> GetTimeTables(string environment, string key, string secret)
    {
        return _client.GetTimeTables(environment, key, secret);
    }

    public Task<IEnumerable<Hours>> GetProjectHours(string environment, string key, string secret, string projectId)
    {
        return _client.GetProjectHours(environment, key, secret, projectId);
    }

    public Task<IEnumerable<Invoice>> GetProjectInvoices(string environment, string key, string secret, string projectId)
    {
        return _client.GetProjectInvoices(environment, key, secret, projectId);
    }

    public Task<IEnumerable<Hours>> GetEmployeeHours(string environment, string key, string secret, string employeeId)
    {
        return _client.GetEmployeeHours(environment, key, secret, employeeId);
    }
}
