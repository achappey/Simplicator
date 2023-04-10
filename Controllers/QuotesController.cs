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
public class QuotesController : ControllerBase
{
    private readonly ILogger<QuotesController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public QuotesController(ILogger<QuotesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    [Tags("Sales")]
    [SwaggerOperation("Fetches all quotes")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IEnumerable<Quote>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetQuotes(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "quote/{id}", Name = "GetQuote")]
    [EnableQuery]
    [SwaggerOperation("Fetches quote for the given quote id")]
    public async Task<Quote?> GetSale([FromRoute] string id)
    {
        var user = this.GetUser();

        return await _simplicateService.GetQuote(user.Environment, user.Key, user.Secret, id);
    }
    

}
