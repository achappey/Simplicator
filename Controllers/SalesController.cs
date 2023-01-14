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

    

    public SalesController(ILogger<SalesController> logger,   IServiceProvider serviceProvider)
    {
        _logger = logger;
         _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet(template: "sales", Name = "GetSales")]
    [EnableQuery]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all sales")]
    public async Task<IEnumerable<Sales>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetSales(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "revenuegroup", Name = "GetRevenueGroups")]
    [EnableQuery]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all revenue groups")]
    [Tags("Sales")]
    public async Task<IEnumerable<LabelLookup>> GetRevenueGroups()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetRevenueGroups(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "quotes", Name = "GetQuotes")]
    [EnableQuery]
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all quotes")]
    [Tags("Sales")]
    public async Task<IEnumerable<Quote>> GetQuotes()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetQuotes(user.Environment, user.Key, user.Secret);
    }
    
    [HttpGet(template: "sales/{id}", Name = "GetSale")]
    [SwaggerOperation("Fetches sale for the given sale id")]
    public async Task<Sales?> GetSale([FromRoute] string id)
    {
        var user = await this.GetUser();

        return await _simplicateService.GetSales(user.Environment, user.Key, user.Secret, id);
    }

    [HttpPut(template: "sales/{id}", Name = "UpdateSales")]
    [SwaggerOperation("Updates a sale for the given id")]
    public async Task<Sales> UpdateSales([FromRoute] string id, [FromBody] Sales sales)
    {
        var user = await this.GetUser();

        return await _simplicateService.UpdateSales(user.Environment, user.Key, user.Secret, id, sales);
    }

    [HttpPost(template: "sales", Name = "AddSales")]
    [SwaggerOperation("Add a new sale")]
    public async Task<Sales> AddSales([FromBody] NewSales sales)
    {
        var user = await this.GetUser();

        return await _simplicateService.AddSales(user.Environment, user.Key, user.Secret, sales);
    }

}
