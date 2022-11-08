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
public class IndustriesController : ControllerBase
{
    private readonly ILogger<IndustriesController> _logger;

    private readonly SimplicateService _simplicateService;

    public IndustriesController(ILogger<IndustriesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all crm industries")]
    public async Task<IEnumerable<Industry>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetIndustries(user.Environment, user.Key, user.Secret);
    }

}
