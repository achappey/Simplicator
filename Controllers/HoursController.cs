using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[Produces("application/json")]
// TEMP
[ApiExplorerSettings(IgnoreApi = true)]

public class HoursController : ControllerBase
{
    private readonly ILogger<HoursController> _logger;

    private readonly SimplicateService _simplicateService;

    public HoursController(ILogger<HoursController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        
         _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

    }

    [HttpGet(template: "hours", Name = "GetHours")]
    [EnableQuery]
    [SwaggerOperation("Fetches all hours")]
    public async Task<IEnumerable<Hours>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetHours(user.Environment, user.Key, user.Secret);
    }

}
