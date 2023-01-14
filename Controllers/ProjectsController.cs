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
public class ProjectsController : ControllerBase
{
    private readonly ILogger<ProjectsController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public ProjectsController(ILogger<ProjectsController> logger,  IServiceProvider serviceProvider)
    {
        _logger = logger;

         _simplicateService = serviceProvider
          .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet(template: "project", Name = "GetProjects")]
    [Tags("Projects")]
    [EnableQuery]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all projects")]
    public async Task<IEnumerable<Project>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetProjects(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "project/{id}/hours", Name = "GetProjectHours")]
    [Tags("Projects")]
    [EnableQuery]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all hours for the given project id")]
    public async Task<IEnumerable<Hours>> GetHours([FromRoute] string id)
    {
        var user = await this.GetUser();

        return await _simplicateService.GetProjectHours(user.Environment, user.Key, user.Secret, id);
    }

    [HttpGet(template: "project/{id}/invoices", Name = "GetProjectInvoices")]
    [Tags("Projects")]
    [EnableQuery]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all invoices for the given project id")]
    public async Task<IEnumerable<Invoice>> GetInvoices([FromRoute] string id)
    {
        var user = await this.GetUser();

        return await _simplicateService.GetProjectInvoices(user.Environment, user.Key, user.Secret, id);
    }

    [HttpGet(template: "service", Name = "GetProjectServices")]
    [Tags("Projects")]
    [EnableQuery]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all project services")]
    public async Task<IEnumerable<ProjectServices>> GetProjectServices()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetProjectServices(user.Environment, user.Key, user.Secret);
    }

    [HttpPost(template: "service", Name = "AddProjectService")]
    [Tags("Projects")]
    [SwaggerOperation("Add a new project service")]
    public async Task<ProjectService> AddProjectService([FromBody] NewProjectService service)
    {
        var user = await this.GetUser();

        return await _simplicateService.AddProjectService(user.Environment, user.Key, user.Secret, service);
    }
    
    [HttpPost(template: "project", Name = "AddProject")]
    [Tags("Projects")]
    [SwaggerOperation("Add a new project")]
    public async Task<Project> AddProject([FromBody] NewProject project)
    {
        var user = await this.GetUser();

        return await _simplicateService.AddProject(user.Environment, user.Key, user.Secret, project);
    }
    
    [HttpGet(template: "project/{id}", Name = "GetProject")]
    [EnableQuery]
    [SwaggerOperation("Fetches project for the given project id")]
    public async Task<Project?> GetProject([FromRoute] string id)
    {
        var user = await this.GetUser();

        return await _simplicateService.GetProject(user.Environment, user.Key, user.Secret, id);
    }

    [HttpPut(template: "service/{id}", Name = "UpdateProjectService")]
    [Tags("Projects")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Updates a project service for the given id")]
    public async Task<ProjectService> UpdateProjectService([FromRoute] string id, [FromBody] ProjectService service)
    {
        var user = await this.GetUser();

        return await _simplicateService.UpdateProjectService(user.Environment, user.Key, user.Secret, id, service);
    }
}
