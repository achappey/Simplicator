using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ILogger<ProjectsController> _logger;

    private readonly SimplicateService _simplicateService;

    public ProjectsController(ILogger<ProjectsController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(template: "project", Name = "GetProjects")]
    [Tags("Projects")]
    [EnableQuery]
    [SwaggerOperation("Fetches all projects")]
    public async Task<IEnumerable<Project>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetProjects(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "{id}/hours", Name = "GetProjectHours")]
    [Tags("Projects")]
    [EnableQuery]
    [SwaggerOperation("Fetches all project hours")]
    public async Task<IEnumerable<Hours>> GetHours([FromRoute] string id)
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetProjectHours(user.Environment, user.Key, user.Secret, id);
    }
}
