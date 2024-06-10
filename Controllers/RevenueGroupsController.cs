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
public class RevenueGroupsController(ILogger<RevenueGroupsController> logger, IServiceProvider serviceProvider) : ControllerBase
{
    private readonly ILogger<RevenueGroupsController> _logger = logger;

    private readonly SimplicateService _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all revenue groups")]
    public async Task<IEnumerable<RevenueGroup>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetRevenueGroups(user.Environment, user.Key, user.Secret);
    }

}
