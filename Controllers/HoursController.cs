using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/hours/[controller]")]
public class HoursController : ControllerBase
{
    private readonly ILogger<HoursController> _logger;

    private readonly SimplicateService _simplicateService;

    public HoursController(ILogger<HoursController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetHours")]
    [EnableQuery]
    [SwaggerOperation("Fetches all hours")]
    public async Task<IEnumerable<Hours>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetHours(user.Environment, user.Key, user.Secret);
    }

}
