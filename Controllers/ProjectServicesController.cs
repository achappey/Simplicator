using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ProjectServicesController : ControllerBase
{
    private readonly ILogger<ProjectServicesController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public ProjectServicesController(ILogger<ProjectServicesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all project services")]
    public async Task<IEnumerable<ProjectServices>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetProjectServices(user.Environment, user.Key, user.Secret);
    }
}
