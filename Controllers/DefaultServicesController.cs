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
public class DefaultServicesController : ControllerBase
{
    private readonly ILogger<DefaultServicesController> _logger;

    private readonly SimplicateService _simplicateService;

    public DefaultServicesController(ILogger<DefaultServicesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all default services")]
    public async Task<IEnumerable<DefaultService>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetDefaultServices(user.Environment, user.Key, user.Secret);
    }
}
