using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RevenueGroupsController : ControllerBase
{
    private readonly ILogger<RevenueGroupsController> _logger;

    private readonly SimplicateService _simplicateService;

    public RevenueGroupsController(ILogger<RevenueGroupsController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetRevenueGroups")]
    [EnableQuery]
    public async Task<IEnumerable<RevenueGroup>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetRevenueGroups(user.Environment, user.Key, user.Secret);
    }
}
