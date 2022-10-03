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
[ApiExplorerSettings(IgnoreApi = true)]
public class QuotesController : ControllerBase
{
    private readonly ILogger<QuotesController> _logger;

    private readonly SimplicateService _simplicateService;

    public QuotesController(ILogger<QuotesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet]
    [EnableQuery]
    [Tags("Sales")]
    [SwaggerOperation("Fetches all quotes")]
    public async Task<IEnumerable<Quote>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetQuotes(user.Environment, user.Key, user.Secret);
    }

}
