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
public class DefaultServicesController(SimplicateService simplicateService) : ControllerBase
{

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all default services")]
    public async Task<IEnumerable<DefaultService>> Get()
    {
        var user = this.GetUser();

        return await simplicateService.GetDefaultServices(user.Environment, user.Key, user.Secret);
    }
}
