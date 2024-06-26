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
public class ServicesController(ILogger<ServicesController> logger, SimplicateService simplicateService) : ControllerBase
{
    private readonly ILogger<ServicesController> _logger = logger;

    private readonly SimplicateService _simplicateService = simplicateService;

    [HttpGet(template: "defaultservice", Name = "GetDefaultServices")]
    [EnableQuery]
    [Tags("Services")]
    [SwaggerOperation("Fetches all default services")]
    public async Task<IEnumerable<DefaultService>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetDefaultServices(user.Environment, user.Key, user.Secret);
    }
}
