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
public class IndustriesController(SimplicateService simplicateService) : ControllerBase
{
    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all crm industries")]
    public async Task<IEnumerable<Industry>> Get()
    {
        var user = this.GetUser();

        return await simplicateService.GetIndustries(user.Environment, user.Key, user.Secret);
    }

}
