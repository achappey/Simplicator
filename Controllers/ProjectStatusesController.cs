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

    private readonly KeyVaultService _keyVaultService;

    public ProjectStatusesController(ILogger<ProjectStatusesController> logger, IServiceProvider serviceProvider)
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
    [SwaggerOperation("Fetches all project statuses")]
    public async Task<IEnumerable<ProjectStatus>> Get()
    {
        var user = await this.GetUser(this._keyVaultService);

        return await _simplicateService.GetProjectStatuses(user.Environment, user.Key, user.Secret);
    }

}
