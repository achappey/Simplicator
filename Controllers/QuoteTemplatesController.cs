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
public class QuoteTemplatesController : ControllerBase
{
    private readonly ILogger<QuoteTemplatesController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public QuoteTemplatesController(ILogger<QuoteTemplatesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all quote templates")]
    public async Task<IEnumerable<QuoteTemplate>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetQuoteTemplates(user.Environment, user.Key, user.Secret);
    }

}
