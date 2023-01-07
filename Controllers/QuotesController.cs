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
        var user = await this.GetUser();

        return await _simplicateService.GetQuotes(user.Environment, user.Key, user.Secret);
    }
    
    [HttpPost(template: "quote", Name = "AddQuote")]
    [SwaggerOperation("Add a new quote")]
    public async Task<NewQuote> AddQuote([FromBody] NewQuote newQuote)
    {
        var user = await this.GetUser();

        return await _simplicateService.AddQuote(user.Environment, user.Key, user.Secret, newQuote);
    }

}
