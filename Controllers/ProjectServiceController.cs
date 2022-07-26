using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Http;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/projects/service")]
public class ProjectServiceController : ControllerBase
{
    private readonly ILogger<ProjectServiceController> _logger;

    private readonly SimplicateService _simplicateService;

    public ProjectServiceController(ILogger<ProjectServiceController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetProjectServices")]
    [Tags("Projects")]
    [EnableQuery]
    [SwaggerOperation("Fetches all project services")]
    public async Task<IEnumerable<ProjectServices>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetProjectServices(user.Environment, user.Key, user.Secret);
    }

    [HttpPost(Name = "AddProjectService")]
    [Tags("Projects")]
    [SwaggerOperation("Add a new project service")]
    public async Task<ProjectService> Post([FromBody] NewProjectService service)
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.AddProjectService(user.Environment, user.Key, user.Secret, service);
    }

    [HttpPut(template: "{id}", Name = "UpdateProjectService")]
    [Tags("Projects")]
    [SwaggerOperation("Updates a project service for the given id")]
    public async Task<ProjectService> Put([FromRoute] string id, [FromBody] ProjectService service)
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.UpdateProjectService(user.Environment, user.Key, user.Secret, id, service);
    }

}
