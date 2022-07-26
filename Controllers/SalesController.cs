using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ILogger<SalesController> _logger;

    private readonly SimplicateService _simplicateService;

    public SalesController(ILogger<SalesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(template: "sales", Name = "GetSales")]
    [EnableQuery]
    [SwaggerOperation("Fetches all sales")]
    public async Task<IEnumerable<Sales>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetSales(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "revenuegroup", Name = "GetRevenueGroups")]
    [EnableQuery]
    [SwaggerOperation("Fetches all revenue groups")]
    [Tags("Sales")]
    public async Task<IEnumerable<RevenueGroup>> GetRevenueGroups()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetRevenueGroups(user.Environment, user.Key, user.Secret);
    }
}
