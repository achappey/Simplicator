﻿using Simplicate.NET.Models;
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

    public async Task<Organization?> GetOrganization(string environment, string key, string secret, string id)
    {
        return await this._httpClient.GetOrganization(environment, key, secret, id);
    }

    public async Task<Sales?> GetSales(string environment, string key, string secret, string id)
    {
        return await this._httpClient.GetSales(environment, key, secret, id);
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

    public async Task<IEnumerable<MessageType>> GetMessageTypes(string environment, string key, string secret)
    {
        return await this._httpClient.GetMessageTypes(environment, key, secret);
    }

    public async Task<IEnumerable<DocumentType>> GetDocumentTypes(string environment, string key, string secret)
    {
        return await this._httpClient.GetDocumentTypes(environment, key, secret);
    }

    public async Task<IEnumerable<Document>> GetDocuments(string environment, string key, string secret)
    {
        return await this._httpClient.GetDocuments(environment, key, secret);
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

    public async Task<IEnumerable<SalesService>> GetSalesServices(string environment, string key, string secret)
    {
        return await this._httpClient.GetSalesServices(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetHours(string environment, string key, string secret)
    {
        return await this._httpClient.GetHours(environment, key, secret);
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

    public async Task<string?> AddSales(string environment, string key, string secret, Sales sales)
    {
        return await this._httpClient.AddSales(environment, key, secret, sales);
    }
    
    public async Task<string?> AddQuote(string environment, string key, string secret, NewQuote quote)
    {
        return await this._httpClient.AddQuote(environment, key, secret, quote);
    }


    public async Task<string?> AddProject(string environment, string key, string secret, NewProject service)
    {
        return await this._httpClient.AddProject(environment, key, secret, service);
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

    public async Task<string?> UpdateOrganization(string environment, string key, string secret, string id, Organization organization)
    {
        return await this._httpClient.UpdateOrganization(environment, key, secret, id, organization);
    }
    
    public async Task<string?> UpdateSales(string environment, string key, string secret, string id, Sales sales)
    {
        return await this._httpClient.UpdateSales(environment, key, secret, id, sales);
    }
}
