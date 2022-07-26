using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly ILogger<ServicesController> _logger;

    private readonly SimplicateService _simplicateService;

    public ServicesController(ILogger<ServicesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(template: "defaultservice", Name = "GetDefaultServices")]
    [EnableQuery]
    [Tags("Services")]
    [SwaggerOperation("Fetches all default services")]
    public async Task<IEnumerable<DefaultService>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetDefaultServices(user.Environment, user.Key, user.Secret);
    }
}
