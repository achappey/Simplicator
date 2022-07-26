using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/sales/[controller]")]
public class RevenueGroupController : ControllerBase
{
    private readonly ILogger<RevenueGroupController> _logger;

    private readonly SimplicateService _simplicateService;

    public RevenueGroupController(ILogger<RevenueGroupController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetRevenueGroups")]
    [EnableQuery]
    [SwaggerOperation("Fetches all revenue groups")]
    [Tags("Sales")]
    public async Task<IEnumerable<RevenueGroup>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetRevenueGroups(user.Environment, user.Key, user.Secret);
    }
}
