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

    private readonly KeyVaultService _keyVaultService;

    public ProjectServicesController(ILogger<ProjectServicesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

        _keyVaultService = serviceProvider
          .GetService<KeyVaultService>() ??
            null!;
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all project services")]
    public async Task<IEnumerable<ProjectServices>> Get()
    {
        var user = await this.HttpContext.GetUser(this._keyVaultService);
var das =  await _simplicateService.GetProjectServices(user.Environment, user.Key, user.Secret);
        return await _simplicateService.GetProjectServices(user.Environment, user.Key, user.Secret);
    }
}
