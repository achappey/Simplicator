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
public class InterestsController(ILogger<InterestsController> logger, IServiceProvider serviceProvider) : ControllerBase
{
    private readonly ILogger<InterestsController> _logger = logger;

    private readonly SimplicateService _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all interests")]
    public async Task<IEnumerable<Interest>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetInterests(user.Environment, user.Key, user.Secret);
    }

}
