using Simplicate.NET.Models;
using Simplicate.NET.Extensions;

namespace Simplicate.NET;

public class SimplicateClient(HttpClient client)
{
    private readonly HttpClient _httpClient = client;

    public Task<IEnumerable<Person>> GetPersons(string environment, string key, string secret)
    {
        return _httpClient.GetPersons(environment, key, secret);
    }

    public Task<IEnumerable<Organization>> GetOrganizations(string environment, string key, string secret)
    {
        return _httpClient.GetOrganizations(environment, key, secret);
    }

    public Task<Organization?> GetOrganization(string environment, string key, string secret, string id)
    {
        return _httpClient.GetOrganization(environment, key, secret, id);
    }

    public Task<Sales?> GetSales(string environment, string key, string secret, string id)
    {
        return _httpClient.GetSales(environment, key, secret, id);
    }

    public Task<Project?> GetProject(string environment, string key, string secret, string id)
    {
        return _httpClient.GetProject(environment, key, secret, id);
    }


    public Task<Quote?> GetQuote(string environment, string key, string secret, string id)
    {
        return _httpClient.GetQuote(environment, key, secret, id);
    }

    public Task<IEnumerable<MyOrganization>> GetMyOrganizations(string environment, string key, string secret)
    {
        return _httpClient.GetMyOrganizations(environment, key, secret);
    }

    public Task<IEnumerable<Project>> GetProjects(string environment, string key, string secret)
    {
        return _httpClient.GetProjects(environment, key, secret);
    }

    public Task<IEnumerable<Sales>> GetSales(string environment, string key, string secret)
    {
        return _httpClient.GetSales(environment, key, secret);
    }

    public Task<IEnumerable<Quote>> GetQuotes(string environment, string key, string secret)
    {
        return _httpClient.GetQuotes(environment, key, secret);
    }

    public Task<IEnumerable<QuoteStatus>> GetQuoteStatuses(string environment, string key, string secret)
    {
        return _httpClient.GetQuoteStatuses(environment, key, secret);
    }

    public Task<IEnumerable<Industry>> GetIndustries(string environment, string key, string secret)
    {
        return _httpClient.GetIndustries(environment, key, secret);
    }

    public Task<IEnumerable<QuoteTemplate>> GetQuoteTemplates(string environment, string key, string secret)
    {
        return _httpClient.GetQuoteTemplates(environment, key, secret);
    }

    public Task<IEnumerable<ProjectStatus>> GetProjectStatuses(string environment, string key, string secret)
    {
        return _httpClient.GetProjectStatuses(environment, key, secret);
    }


    public Task<IEnumerable<InvoiceStatus>> GetInvoiceStatuses(string environment, string key, string secret)
    {
        return _httpClient.GetInvoiceStatuses(environment, key, secret);
    }

    public Task<IEnumerable<SalesStatus>> GetSalesStatuses(string environment, string key, string secret)
    {
        return _httpClient.GetSalesStatuses(environment, key, secret);
    }

    public Task<IEnumerable<SalesSource>> GetSalesSources(string environment, string key, string secret)
    {
        return _httpClient.GetSalesSources(environment, key, secret);
    }

    public Task<IEnumerable<RevenueGroup>> GetRevenueGroups(string environment, string key, string secret)
    {
        return _httpClient.GetRevenueGroups(environment, key, secret);
    }

    public Task<IEnumerable<SalesProgress>> GetSalesProgresses(string environment, string key, string secret)
    {
        return _httpClient.GetSalesProgresses(environment, key, secret);
    }

    public Task<IEnumerable<Interest>> GetInterests(string environment, string key, string secret)
    {
        return _httpClient.GetInterests(environment, key, secret);
    }

    public Task<IEnumerable<Contract>> GetContracts(string environment, string key, string secret)
    {
        return _httpClient.GetContracts(environment, key, secret);
    }

    public Task<IEnumerable<DefaultService>> GetDefaultServices(string environment, string key, string secret)
    {
        return _httpClient.GetDefaultServices(environment, key, secret);
    }

    public Task<IEnumerable<VatClass>> GetVatClasses(string environment, string key, string secret)
    {
        return _httpClient.GetVatClasses(environment, key, secret);
    }

    public Task<IEnumerable<Employee>> GetEmployees(string environment, string key, string secret)
    {
        return _httpClient.GetEmployees(environment, key, secret);
    }

    public Task<IEnumerable<Invoice>> GetInvoices(string environment, string key, string secret)
    {
        return _httpClient.GetInvoices(environment, key, secret);
    }

    public Task<IEnumerable<ProjectServices>> GetProjectServices(string environment, string key, string secret)
    {
        return _httpClient.GetProjectServices(environment, key, secret);
    }

    public Task<IEnumerable<SalesService>> GetSalesServices(string environment, string key, string secret)
    {
        return _httpClient.GetSalesServices(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetHours(string environment, string key, string secret)
    {
        var employees = await GetEmployees(environment, key, secret);
        var hours = await _httpClient.GetHours(environment, key, secret);

        var employeeMap = employees.ToDictionary(emp => emp.Id, emp => emp);

        foreach (var hour in hours)
        {
            if (employeeMap.TryGetValue(hour.EmployeeId, out var matchingEmployee))
            {
                hour.EmployeeWorkEmail = matchingEmployee.WorkEmail;
            }
        }

        return hours;
    }

    public Task<int> GetHourPageCount(string environment, string key, string secret)
    {
        return _httpClient.GetHourCount(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetHourPage(string environment, string key, string secret, int top, int skip)
    {
        var employees = await GetEmployees(environment, key, secret);
        var hours = await _httpClient.GetHourPage(environment, key, secret, top, skip);

        var employeeMap = employees.ToDictionary(emp => emp.Id, emp => emp);

        foreach (var hour in hours)
        {
            if (employeeMap.TryGetValue(hour.EmployeeId, out var matchingEmployee))
            {
                hour.EmployeeWorkEmail = matchingEmployee.WorkEmail;
            }
        }

        return hours;
    }

    public async Task<IEnumerable<Hours>> GetHoursByYear(string environment, string key, string secret, int year)
    {
        var employees = await GetEmployees(environment, key, secret);
        var hours = await _httpClient.GetHoursByYear(environment, key, secret, year);

        var employeeMap = employees.ToDictionary(emp => emp.Id, emp => emp);

        foreach (var hour in hours)
        {
            if (employeeMap.TryGetValue(hour.EmployeeId, out var matchingEmployee))
            {
                hour.EmployeeWorkEmail = matchingEmployee.WorkEmail;
            }
        }

        return hours;
    }

    public async Task<IEnumerable<Hours>> GetHoursAfter(string environment, string key, string secret, DateTimeOffset dateTimeOffset)
    {
        var employees = await GetEmployees(environment, key, secret);
        var hours = await _httpClient.GetHoursAfter(environment, key, secret, dateTimeOffset);

        var employeeMap = employees.ToDictionary(emp => emp.Id, emp => emp);

        foreach (var hour in hours)
        {
            if (employeeMap.TryGetValue(hour.EmployeeId, out var matchingEmployee))
            {
                hour.EmployeeWorkEmail = matchingEmployee.WorkEmail;
            }
        }

        return hours;
    }
    public Task<int> GetHourPageCountAfter(string environment, string key, string secret, DateTimeOffset dateTimeOffset)
    {
        return _httpClient.GetHourCountAfter(environment, key, secret, dateTimeOffset);
    }
    public Task<int> GetHourPageCountByYear(string environment, string key, string secret, int year)
    {
        return _httpClient.GetHourCountByYear(environment, key, secret, year);
    }

    public async Task<IEnumerable<Hours>> GetHourPageByYear(string environment, string key, string secret, int top, int skip, int year)
    {
        var employees = await GetEmployees(environment, key, secret);
        var hours = await _httpClient.GetHourPageByYear(environment, key, secret, top, skip, year);

        var employeeMap = employees.ToDictionary(emp => emp.Id, emp => emp);

        foreach (var hour in hours)
        {
            if (employeeMap.TryGetValue(hour.EmployeeId, out var matchingEmployee))
            {
                hour.EmployeeWorkEmail = matchingEmployee.WorkEmail;
            }
        }

        return hours;
    }

    public async Task<IEnumerable<Hours>> GetHourPageAfter(string environment, string key, string secret, int top, int skip, DateTimeOffset date)
    {
        var employees = await GetEmployees(environment, key, secret);
        var hours = await _httpClient.GetHourPageAfter(environment, key, secret, top, skip, date);

        var employeeMap = employees.ToDictionary(emp => emp.Id, emp => emp);

        foreach (var hour in hours)
        {
            if (employeeMap.TryGetValue(hour.EmployeeId, out var matchingEmployee))
            {
                hour.EmployeeWorkEmail = matchingEmployee.WorkEmail;
            }
        }

        return hours;
    }

    public Task<IEnumerable<Leave>> GetLeaves(string environment, string key, string secret)
    {
        return _httpClient.GetLeaves(environment, key, secret);
    }

    public Task<IEnumerable<TimeTable>> GetTimeTables(string environment, string key, string secret)
    {
        return _httpClient.GetTimeTables(environment, key, secret);
    }

    public Task<IEnumerable<Hours>> GetProjectHours(string environment, string key, string secret, string projectId)
    {
        return _httpClient.GetProjectHours(environment, key, secret, projectId);
    }

    public Task<IEnumerable<Invoice>> GetProjectInvoices(string environment, string key, string secret, string projectId)
    {
        return _httpClient.GetProjectInvoices(environment, key, secret, projectId);
    }

    public Task<IEnumerable<Hours>> GetEmployeeHours(string environment, string key, string secret, string employeeId)
    {
        return _httpClient.GetEmployeeHours(environment, key, secret, employeeId);
    }

    public Task<string?> AddProjectService(string environment, string key, string secret, NewProjectService service)
    {
        return _httpClient.AddProjectService(environment, key, secret, service);
    }

    public Task<string?> UpdateProjectService(string environment, string key, string secret, string id, ProjectService service)
    {
        return _httpClient.UpdateProjectService(environment, key, secret, id, service);
    }

}
