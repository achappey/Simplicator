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

        //        var dsadsa = projects.SelectMany(t => t.CustomFields?.Select(a => a.Type)).ToList();

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
            if (customField.RenderType == "dropdown")
            {
                expandoDict[customField.Name] = customField.Options?.FirstOrDefault(a => a.Value == customField.Value)?.Label ?? null;
            }
            else if (customField.RenderType == "boolean")
            {
                expandoDict[customField.Name] = !string.IsNullOrEmpty(customField.Value) ?
                    ParseBoolean(customField.Value) : null;
            }
            else
            {
                expandoDict[customField.Name] = customField.Value ?? null;
            }
        }

        return expando;
    }

    private static bool ParseBoolean(string value)
    {
        return value == "1" || value.Equals("true", StringComparison.OrdinalIgnoreCase);
    }


}
