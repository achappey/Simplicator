using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
//[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly ILogger<ProjectsController> _logger;

    private readonly SimplicateService _simplicateService;

    private readonly KeyVaultService _keyVaultService;

    public ProjectsController(ILogger<ProjectsController> logger, SimplicateService simplicateService, KeyVaultService keyVaultService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
        _keyVaultService = keyVaultService;
    }

    [HttpGet(template: "project", Name = "GetProjects")]
    [Tags("Projects")]
    [EnableQuery]
    [SwaggerOperation("Fetches all projects")]
    public async Task<IEnumerable<Project>> Get()
    {
        try
        {
            var user = await this.HttpContext.GetUser(this._keyVaultService);

            return await _simplicateService.GetProjects(user.Environment, user.Key, user.Secret);
        }
        catch (Exception e)
        {
            this._logger.LogError(e, e.Message);
             return new List<Project>() {
                new Project() {
                    Name = e.Message
                }
             };
        }

       
    }

    [HttpGet(template: "project/{id}/hours", Name = "GetProjectHours")]
    [Tags("Projects")]
    [EnableQuery]
    [SwaggerOperation("Fetches all hours for the given project id")]
    public async Task<IEnumerable<Hours>> GetHours([FromRoute] string id)
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.GetProjectHours(user.Environment, user.Key, user.Secret, id);
    }

    [HttpGet(template: "service", Name = "GetProjectServices")]
    [Tags("Projects")]
    [EnableQuery]
    [SwaggerOperation("Fetches all project services")]
    public async Task<IEnumerable<ProjectServices>> GetProjectServices()
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.GetProjectServices(user.Environment, user.Key, user.Secret);
    }

    [HttpPost(template: "service", Name = "AddProjectService")]
    [Tags("Projects")]
    [SwaggerOperation("Add a new project service")]
    public async Task<ProjectService> AddProjectService([FromBody] NewProjectService service)
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.AddProjectService(user.Environment, user.Key, user.Secret, service);
    }

    [HttpPut(template: "service/{id}", Name = "UpdateProjectService")]
    [Tags("Projects")]
    [SwaggerOperation("Updates a project service for the given id")]
    public async Task<ProjectService> UpdateProjectService([FromRoute] string id, [FromBody] ProjectService service)
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.UpdateProjectService(user.Environment, user.Key, user.Secret, id, service);
    }
}
