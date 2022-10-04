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
public class SalesController : ControllerBase
{
    private readonly ILogger<SalesController> _logger;

    private readonly SimplicateService _simplicateService;

    private readonly KeyVaultService _keyVaultService;

    public SalesController(ILogger<SalesController> logger,   IServiceProvider serviceProvider)
    {
        _logger = logger;
         _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

        _keyVaultService = serviceProvider
          .GetService<KeyVaultService>() ??
            null!;
    }

    [HttpGet(template: "sales", Name = "GetSales")]
    [EnableQuery]
    [SwaggerOperation("Fetches all sales")]
    public async Task<IEnumerable<Sales>> Get()
    {
        var user = await this.HttpContext.GetUser(this._keyVaultService);

        return await _simplicateService.GetSales(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "revenuegroup", Name = "GetRevenueGroups")]
    [EnableQuery]
    [SwaggerOperation("Fetches all revenue groups")]
    [Tags("Sales")]
    public async Task<IEnumerable<LabelLookup>> GetRevenueGroups()
    {
        var user = await this.HttpContext.GetUser(this._keyVaultService);

        return await _simplicateService.GetRevenueGroups(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "quotes", Name = "GetQuotes")]
    [EnableQuery]
    [SwaggerOperation("Fetches all quotes")]
    [Tags("Sales")]
    public async Task<IEnumerable<Quote>> GetQuotes()
    {
        var user = await this.HttpContext.GetUser(this._keyVaultService);

        return await _simplicateService.GetQuotes(user.Environment, user.Key, user.Secret);
    }
}
