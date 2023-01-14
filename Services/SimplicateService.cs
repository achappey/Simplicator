using Simplicate.NET;
using Simplicate.NET.Models;
using Simplicate.NET.Models.Http;

namespace Simplicator.Services;

public class SimplicateService
{
    private readonly SimplicateClient _client;

    public SimplicateService(
        SimplicateClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Project>> GetProjects(string environment, string key, string secret)
    {
        return await this._client.GetProjects(environment, key, secret);
    }

    public async Task<IEnumerable<Sales>> GetSales(string environment, string key, string secret)
    {
        return await this._client.GetSales(environment, key, secret);
    }

    public async Task<IEnumerable<Quote>> GetQuotes(string environment, string key, string secret)
    {
        return await this._client.GetQuotes(environment, key, secret);
    }

    public async Task<IEnumerable<QuoteStatus>> GetQuoteStatuses(string environment, string key, string secret)
    {
        return await this._client.GetQuoteStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<Industry>> GetIndustries(string environment, string key, string secret)
    {
        return await this._client.GetIndustries(environment, key, secret);
    }

    public async Task<IEnumerable<QuoteTemplate>> GetQuoteTemplates(string environment, string key, string secret)
    {
        return await this._client.GetQuoteTemplates(environment, key, secret);
    }

    public async Task<IEnumerable<ProjectStatus>> GetProjectStatuses(string environment, string key, string secret)
    {
        return await this._client.GetProjectStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<InvoiceStatus>> GetInvoiceStatuses(string environment, string key, string secret)
    {
        return await this._client.GetInvoiceStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<SalesStatus>> GetSalesStatuses(string environment, string key, string secret)
    {
        return await this._client.GetSalesStatuses(environment, key, secret);
    }

    public async Task<IEnumerable<SalesSource>> GetSalesSources(string environment, string key, string secret)
    {
        return await this._client.GetSalesSources(environment, key, secret);
    }
    public async Task<IEnumerable<SalesProgress>> GetSalesProgresses(string environment, string key, string secret)
    {
        return await this._client.GetSalesProgresses(environment, key, secret);
    }

    public async Task<IEnumerable<MessageType>> GetMessageTypes(string environment, string key, string secret)
    {
        return await this._client.GetMessageTypes(environment, key, secret);
    }

    public async Task<IEnumerable<DocumentType>> GetDocumentTypes(string environment, string key, string secret)
    {
        return await this._client.GetDocumentTypes(environment, key, secret);
    }

    public async Task<IEnumerable<Document>> GetDocuments(string environment, string key, string secret)
    {
        return await this._client.GetDocuments(environment, key, secret);
    }

    public async Task<IEnumerable<Person>> GetPersons(string environment, string key, string secret)
    {
        return await this._client.GetPersons(environment, key, secret);
    }

    public async Task<IEnumerable<Organization>> GetOrganizations(string environment, string key, string secret)
    {
        return await this._client.GetOrganizations(environment, key, secret);
    }

    public async Task<Organization?> GetOrganization(string environment, string key, string secret, string id)
    {
        return await this._client.GetOrganization(environment, key, secret, id);
    }

    public async Task<Sales?> GetSales(string environment, string key, string secret, string id)
    {
        return await this._client.GetSales(environment, key, secret, id);
    }

    public async Task<Quote?> GetQuote(string environment, string key, string secret, string id)
    {
        return await this._client.GetQuote(environment, key, secret, id);
    }

    public async Task<IEnumerable<MyOrganization>> GetMyOrganizations(string environment, string key, string secret)
    {
        return await this._client.GetMyOrganizations(environment, key, secret);
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

    public async Task<IEnumerable<SalesService>> GetSalesServices(string environment, string key, string secret)
    {
        return await this._client.GetSalesServices(environment, key, secret);
    }

    public async Task<ProjectService> AddProjectService(string environment, string key, string secret, NewProjectService service)
    {
        service.Id = await this._client.AddProjectService(environment, key, secret, service);

        return service;
    }

    public async Task<Quote> AddQuote(string environment, string key, string secret, NewQuote quote)
    {
          var id = await this._client.AddQuote(environment, key, secret, quote);

        return id != null ? new Quote()
        {
            Id = id
        } : throw new SimplicateResponseException(500, "Could not create quote");
    }

    public async Task<Sales> AddSales(string environment, string key, string secret, NewSales sales)
    {
        var id = await this._client.AddSales(environment, key, secret, sales);

        return id != null ? new Sales()
        {
            Id = id
        } : throw new SimplicateResponseException(500, "Could not create sales");

    }

    public async Task<Project> AddProject(string environment, string key, string secret, NewProject service)
    {

        var id = await this._client.AddProject(environment, key, secret, service);

        return id != null ? new Project()
        {
            Id = id
        } : throw new SimplicateResponseException(500, "Could not create project");
    }

    public async Task<Invoice> AddInvoice(string environment, string key, string secret, NewInvoice invoice)
    {
        var id = await this._client.AddInvoice(environment, key, secret, invoice);

        return id != null ? new Invoice()
        {
            Id = id
        } : throw new SimplicateResponseException(500, "Could not create invoice");
    }

    public async Task<Message> AddMessage(string environment, string key, string secret, NewMessage message)
    {
        var id = await this._client.AddMessage(environment, key, secret, message);

        return id != null ? new Message()
        {
            Id = id
        } : throw new SimplicateResponseException(500, "Could not create message");
    }

    public async Task<ProjectService> UpdateProjectService(string environment, string key, string secret, string id, ProjectService service)
    {
        service.Id = await this._client.UpdateProjectService(environment, key, secret, id, service);

        return service;
    }

    public async Task<Organization> UpdateOrganization(string environment, string key, string secret, string id, Organization organization)
    {
        var newId = await this._client.UpdateOrganization(environment, key, secret, id, organization);

        if (newId != null)
        {
            organization.Id = newId;
        }

        return organization;
    }

    
    public async Task<Sales> UpdateSales(string environment, string key, string secret, string id, Sales sales)
    {
        var newId = await this._client.UpdateSales(environment, key, secret, id, sales);

        if (newId != null)
        {
            sales.Id = newId;
        }

        return sales;
    }

    public async Task<IEnumerable<Invoice>> GetInvoices(string environment, string key, string secret)
    {
        return await this._client.GetInvoices(environment, key, secret);
    }

    public async Task<IEnumerable<Employee>> GetEmployees(string environment, string key, string secret)
    {
        return await this._client.GetEmployees(environment, key, secret);
    }

    public async Task<IEnumerable<Contract>> GetContracts(string environment, string key, string secret)
    {
        return await this._client.GetContracts(environment, key, secret);
    }

    public async Task<IEnumerable<Message>> GetAllMessages(string environment, string key, string secret)
    {
        return await this._client.GetAllMessages(environment, key, secret);
    }

    public async Task<IEnumerable<Message>> GetMessagesLastWeek(string environment, string key, string secret)
    {
        return await this._client.GetMessagesLastWeek(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetHours(string environment, string key, string secret)
    {
        return await this._client.GetHours(environment, key, secret);
    }

    public async Task<IEnumerable<Hours>> GetProjectHours(string environment, string key, string secret, string projectId)
    {
        return await this._client.GetProjectHours(environment, key, secret, projectId);
    }

    public async Task<IEnumerable<Invoice>> GetProjectInvoices(string environment, string key, string secret, string projectId)
    {
        return await this._client.GetProjectInvoices(environment, key, secret, projectId);
    }

    public async Task<IEnumerable<Hours>> GetEmployeeHours(string environment, string key, string secret, string employeeId)
    {
        return await this._client.GetEmployeeHours(environment, key, secret, employeeId);
    }
}
