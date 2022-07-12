using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ILogger<ProjectsController> _logger;

    private readonly SimplicateService _simplicateService;

    public ProjectsController(ILogger<ProjectsController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetProjects")]
    [EnableQuery]
    public async Task<IEnumerable<Project>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetProjects(user.Environment, user.Key, user.Secret);
    }
}
