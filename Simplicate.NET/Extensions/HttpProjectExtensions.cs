
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

    public static async Task<string?> AddProjectService(this HttpClient client, string environment, string key, string secret, NewProjectService service)
    {
        var item = await client.SimplicatePostRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.PROJECTSERVICE),
            key, secret, service);

        return item?.Id;
    }

    public static async Task<string?> UpdateProjectService(this HttpClient client, string environment, string key, string secret, string id, ProjectService service)
    {
        var item = await client.SimplicatePutRequest<NewResource>(
            environment.BuildRequestUri(Endpoints.PROJECTSERVICE, id),
            key, secret, service);

        return item?.Id;
    }

    public static async Task<IEnumerable<Hours>> GetProjectHours(this HttpClient client, string environment, string key, string secret, string projectId)
    {
        return await client.PagedRequest<Hours>(environment.BuildRequestUri(Endpoints.HOURS, null, string.Format("q[project.id]={0}", projectId)), key, secret);
    }


}
