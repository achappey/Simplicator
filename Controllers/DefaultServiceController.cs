using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/services/[controller]")]
public class DefaultServiceController : ControllerBase
{
    private readonly ILogger<DefaultServiceController> _logger;

    private readonly SimplicateService _simplicateService;

    public DefaultServiceController(ILogger<DefaultServiceController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetDefaultServices")]
    [EnableQuery]
    [Tags("Services")]
     [SwaggerOperation("Fetches all default services")]
    public async Task<IEnumerable<DefaultService>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetDefaultServices(user.Environment, user.Key, user.Secret);
    }
}
