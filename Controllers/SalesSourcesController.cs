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
public class SalesSourcesController : ControllerBase
{
    private readonly ILogger<SalesSourcesController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public SalesSourcesController(ILogger<SalesSourcesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all sales sources")]
    public async Task<IEnumerable<SalesSource>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetSalesSources(user.Environment, user.Key, user.Secret);
    }

}
