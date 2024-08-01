using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.Dynamic;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class ProjectFieldsController(ILogger<ProjectsController> logger, SimplicateService serviceProvider) : ControllerBase
{
    private readonly ILogger<ProjectsController> _logger = logger;
  
    [HttpGet(template: "projectfields", Name = "GetProjectFields")]
    [Tags("Projects")]
    [EnableQuery]
    [SwaggerOperation("Fetches all project custom fields")]
    public async Task<IEnumerable<dynamic>> Get()
    {
        var user = this.GetUser();

        var projects = await serviceProvider.GetProjects(user.Environment, user.Key, user.Secret);

        var items = projects.Select(t => CreateDynamicProject(t)).ToList();

        return items;
    }

    static dynamic CreateDynamicProject(Project project)
    {
        dynamic expando = new ExpandoObject();
        expando.Id = project.Id;

        var expandoDict = (IDictionary<string, object?>)expando;
        foreach (var customField in project.CustomFields ?? [])
        {
            expandoDict[customField.Name] = customField.Value ?? null;
        }

        return expando;
    }


}
