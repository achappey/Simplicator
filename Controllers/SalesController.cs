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
public class SalesController(ILogger<SalesController> logger, IServiceProvider serviceProvider) : ControllerBase
{
    private readonly ILogger<SalesController> _logger = logger;

    private readonly SimplicateService _simplicateService = serviceProvider
      .GetRequiredService<SimplicateService>();

    [HttpGet(template: "sales", Name = "GetSales")]
    [EnableQuery]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all sales")]
    public async Task<IEnumerable<Sales>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetSales(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "revenuegroup", Name = "GetRevenueGroups")]
    [EnableQuery]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all revenue groups")]
    [Tags("Sales")]
    public async Task<IEnumerable<LabelLookup>> GetRevenueGroups()
    {
        var user = this.GetUser();

        return await _simplicateService.GetRevenueGroups(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "quotes", Name = "GetQuotes")]
    [EnableQuery]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all quotes")]
    [Tags("Sales")]
    public async Task<IEnumerable<Quote>> GetQuotes()
    {
        var user = this.GetUser();

        return await _simplicateService.GetQuotes(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "sales/{id}", Name = "GetSale")]
    [SwaggerOperation("Fetches sale for the given sale id")]
    public async Task<Sales?> GetSale([FromRoute] string id)
    {
        var user = this.GetUser();

        return await _simplicateService.GetSales(user.Environment, user.Key, user.Secret, id);
    }

}
