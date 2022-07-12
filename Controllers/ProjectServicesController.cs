using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectServicesController : ControllerBase
{
    private readonly ILogger<ProjectServicesController> _logger;

    private readonly SimplicateService _simplicateService;

    public ProjectServicesController(ILogger<ProjectServicesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetProjectServices")]
    [EnableQuery]
    public async Task<IEnumerable<ProjectService>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetProjectServices(user.Environment, user.Key, user.Secret);
    }

    [HttpPost(Name = "AddProjectService")]
    public async Task<ProjectService> Post([FromBody] ProjectService service)
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.AddProjectService(user.Environment, user.Key, user.Secret, service);
    }
}
