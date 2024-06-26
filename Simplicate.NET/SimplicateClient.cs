﻿using Simplicate.NET.Models;
using Simplicate.NET.Extensions;

namespace Simplicate.NET;

public class SimplicateClient(HttpClient client)
{
    private readonly HttpClient _httpClient = client;

    public async Task<IEnumerable<Person>> GetPersons(string environment, string key, string secret)
    {
        return await this._httpClient.GetPersons(environment, key, secret);
    }

    public async Task<IEnumerable<Organization>> GetOrganizations(string environment, string key, string secret)
    {
        return await this._httpClient.GetOrganizations(environment, key, secret);
    }

    public async Task<Organization?> GetOrganization(string environment, string key, string secret, string id)
    {
        return await this._httpClient.GetOrganization(environment, key, secret, id);
    }

    public async Task<Sales?> GetSales(string environment, string key, string secret, string id)
    {
        return await this._httpClient.GetSales(environment, key, secret, id);
    }

    public async Task<Project?> GetProject(string environment, string key, string secret, string id)
    {
        return await this._httpClient.GetProject(environment, key, secret, id);
    }


    public async Task<Quote?> GetQuote(string environment, string key, string secret, string id)
    {
        return await this._httpClient.GetQuote(environment, key, secret, id);
    }

    public async Task<IEnumerable<MyOrganization>> GetMyOrganizations(string environment, string key, string secret)
    {
        return await this._httpClient.GetMyOrganizations(environment, key, secret);
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

    public async Task<IEnumerable<QuoteStatus>> GetQuoteStatuses(string environment, string key, string secret)
    {
        return await this._httpClient.GetQuoteStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<Industry>> GetIndustries(string environment, string key, string secret)
    {
        return await this._httpClient.GetIndustries(environment, key, secret);
    }

    public async Task<IEnumerable<QuoteTemplate>> GetQuoteTemplates(string environment, string key, string secret)
    {
        return await this._httpClient.GetQuoteTemplates(environment, key, secret);
    }

    public async Task<IEnumerable<ProjectStatus>> GetProjectStatuses(string environment, string key, string secret)
    {
        return await this._httpClient.GetProjectStatuses(environment, key, secret);
    }


    public async Task<IEnumerable<InvoiceStatus>> GetInvoiceStatuses(string environment, string key, string secret)
    {
        return await this._httpClient.GetInvoiceStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<SalesStatus>> GetSalesStatuses(string environment, string key, string secret)
    {
        return await this._httpClient.GetSalesStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<SalesSource>> GetSalesSources(string environment, string key, string secret)
    {
        return await this._httpClient.GetSalesSources(environment, key, secret);
    }

    public async Task<IEnumerable<RevenueGroup>> GetRevenueGroups(string environment, string key, string secret)
    {
        return await this._httpClient.GetRevenueGroups(environment, key, secret);
    }

    public async Task<IEnumerable<SalesProgress>> GetSalesProgresses(string environment, string key, string secret)
    {
        return await this._httpClient.GetSalesProgresses(environment, key, secret);
    }

     public async Task<IEnumerable<Interest>> GetInterests(string environment, string key, string secret)
    {
        return await this._httpClient.GetInterests(environment, key, secret);
    }

     public async Task<IEnumerable<Contract>> GetContracts(string environment, string key, string secret)
    {
        return await this._httpClient.GetContracts(environment, key, secret);
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

    public async Task<IEnumerable<Invoice>> GetInvoices(string environment, string key, string secret)
    {
        return await this._httpClient.GetInvoices(environment, key, secret);
    }

    public async Task<IEnumerable<ProjectServices>> GetProjectServices(string environment, string key, string secret)
    {
        return await this._httpClient.GetProjectServices(environment, key, secret);
    }

    public async Task<IEnumerable<SalesService>> GetSalesServices(string environment, string key, string secret)
    {
        return await this._httpClient.GetSalesServices(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetHours(string environment, string key, string secret)
    {
        var employees = await this.GetEmployees(environment, key, secret);
        var hours = await this._httpClient.GetHours(environment, key, secret);

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

    public async Task<int> GetHourPageCount(string environment, string key, string secret)
    {
        return await this._httpClient.GetHourCount(environment, key, secret);
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

    public async Task<int> GetHourPageCountByYear(string environment, string key, string secret, int year)
    {
        return await _httpClient.GetHourCountByYear(environment, key, secret, year);
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

    public async Task<IEnumerable<Leave>> GetLeaves(string environment, string key, string secret)
    {
        return await this._httpClient.GetLeaves(environment, key, secret);
    }

    public async Task<IEnumerable<TimeTable>> GetTimeTables(string environment, string key, string secret)
    {
        return await this._httpClient.GetTimeTables(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetProjectHours(string environment, string key, string secret, string projectId)
    {
        return await this._httpClient.GetProjectHours(environment, key, secret, projectId);
    }

    public async Task<IEnumerable<Invoice>> GetProjectInvoices(string environment, string key, string secret, string projectId)
    {
        return await this._httpClient.GetProjectInvoices(environment, key, secret, projectId);
    }

    public async Task<IEnumerable<Hours>> GetEmployeeHours(string environment, string key, string secret, string employeeId)
    {
        return await this._httpClient.GetEmployeeHours(environment, key, secret, employeeId);
    }

    public async Task<string?> AddProjectService(string environment, string key, string secret, NewProjectService service)
    {
        return await this._httpClient.AddProjectService(environment, key, secret, service);
    }

    public async Task<string?> UpdateProjectService(string environment, string key, string secret, string id, ProjectService service)
    {
        return await this._httpClient.UpdateProjectService(environment, key, secret, id, service);
    }

}
