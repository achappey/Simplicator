using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[Produces("application/json")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ProjectStatusesController : ControllerBase
{
    private readonly ILogger<ProjectStatusesController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public ProjectStatusesController(ILogger<ProjectStatusesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all project statuses")]
    public async Task<IEnumerable<ProjectStatus>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetProjectStatuses(user.Environment, user.Key, user.Secret);
    }

}
