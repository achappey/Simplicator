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
public class RevenueGroupsController : ControllerBase
{
    private readonly ILogger<RevenueGroupsController> _logger;

    private readonly SimplicateService _simplicateService;

    private readonly KeyVaultService _keyVaultService;

    public RevenueGroupsController(ILogger<RevenueGroupsController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

        _keyVaultService = serviceProvider
          .GetService<KeyVaultService>() ??
            null!;
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all revenue groups")]
    public async Task<IEnumerable<RevenueGroup>> Get()
    {
        var user = await this.HttpContext.GetUser(this._keyVaultService);

        return await _simplicateService.GetRevenueGroups(user.Environment, user.Key, user.Secret);
    }

}
