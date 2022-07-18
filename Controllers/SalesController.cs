using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ILogger<SalesController> _logger;

    private readonly SimplicateService _simplicateService;

    public SalesController(ILogger<SalesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetSales")]
    [EnableQuery]
    public async Task<IEnumerable<Sales>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetSales(user.Environment, user.Key, user.Secret);
    }
}
