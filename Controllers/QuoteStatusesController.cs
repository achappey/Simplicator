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
public class QuoteStatusesController : ControllerBase
{
    private readonly ILogger<QuoteStatusesController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public QuoteStatusesController(ILogger<QuoteStatusesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all quote statuses")]
    public async Task<IEnumerable<QuoteStatus>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetQuoteStatuses(user.Environment, user.Key, user.Secret);
    }

}
