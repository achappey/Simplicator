﻿
using Simplicate.NET.Models;
using Simplicate.NET.Models.Http;

namespace Simplicate.NET.Extensions;

public static class HttpProjectExtensions
{

    public static async Task<IEnumerable<Project>> GetProjects(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<Project>(environment.BuildRequestUri(Endpoints.PROJECT), key, secret);
    }
    public static async Task<IEnumerable<ProjectServices>> GetProjectServices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<ProjectServices>(environment.BuildRequestUri(Endpoints.PROJECTSERVICE), key, secret);
    }

    public static async Task<IEnumerable<SalesService>> GetSalesServices(this HttpClient client, string environment, string key, string secret)
    {
        return await client.PagedRequest<SalesService>(environment.BuildRequestUri(Endpoints.SALESSERVICE), key, secret);
    }

    public static async Task<string?> AddProjectService(this HttpClient client, string environment, string key, string secret, NewProjectService service)
    {
        var item = await client.SimplicatePostRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.PROJECTSERVICE),
            key, secret, service);

        return item?.Id;
    }

    public static async Task<string?> AddSales(this HttpClient client, string environment, string key, string secret, NewSales sales)
    {
        var item = await client.SimplicatePostRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.SALES),
            key, secret, sales);

        return item?.Id;
    }
    
    public static async Task<string?> AddQuote(this HttpClient client, string environment, string key, string secret, NewQuote newQuote)
    {
        var item = await client.SimplicatePostRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.QUOTES),
            key, secret, newQuote);

        return item?.Id;
    }

    public static async Task<string?> AddProjectEmployee(this HttpClient client, string environment, string key, string secret, NewProjectEmployee newEmployee)
    {
        var item = await client.SimplicatePostRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.PROJECTEMPLOYEE),
            key, secret, newEmployee);

         return item?.Id;
    }

    public static async Task<string?> AddProject(this HttpClient client, string environment, string key, string secret, NewProject service)
    {
        var item = await client.SimplicatePostRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.PROJECT),
            key, secret, service);

        return item?.Id;
    }

    public static async Task<string?> AddInvoice(this HttpClient client, string environment, string key, string secret, NewInvoice invoice)
    {
        var item = await client.SimplicatePostRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.INVOICE),
            key, secret, invoice);

        return item?.Id;
    }

    public static async Task<string?> UpdateProjectService(this HttpClient client, string environment, string key, string secret, string id, ProjectService service)
    {
        var item = await client.SimplicatePutRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.PROJECTSERVICE, id),
            key, secret, service);

        return item?.Id;
    }

    public static async Task<string?> UpdateOrganization(this HttpClient client, string environment, string key, string secret, string id, Organization organization)
    {
        var item = await client.SimplicatePutRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.ORGANIZATION, id),
            key, secret, organization);

        return item?.Id;
    }
    
    public static async Task<string?> UpdateSales(this HttpClient client, string environment, string key, string secret, string id, Sales sales)
    {
        var item = await client.SimplicatePutRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.SALES, id),
            key, secret, sales);

        return item?.Id;
    }


    public static async Task<IEnumerable<Hours>> GetProjectHours(this HttpClient client, string environment, string key, string secret, string projectId)
    {
        return await client.PagedRequest<Hours>(environment.BuildRequestUri(Endpoints.HOURS, null, string.Format("q[project.id]={0}", projectId)), key, secret);
    }

    public static async Task<IEnumerable<Invoice>> GetProjectInvoices(this HttpClient client, string environment, string key, string secret, string projectId)
    {
        return await client.PagedRequest<Invoice>(environment.BuildRequestUri(Endpoints.INVOICE, null, string.Format("q[projects.id]={0}", projectId)), key, secret);
    }
}
