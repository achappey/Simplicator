using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[Produces("application/json")]
[Authorize]
// TEMP
[ApiExplorerSettings(IgnoreApi = true)]

public class HoursController : ControllerBase
{
    private readonly ILogger<HoursController> _logger;

    private readonly SimplicateService _simplicateService;

    private readonly KeyVaultService _keyVaultService;

    public HoursController(ILogger<HoursController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        
         _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

        _keyVaultService = serviceProvider
          .GetService<KeyVaultService>() ??
            null!;
    }

    [HttpGet(template: "hours", Name = "GetHours")]
    [EnableQuery]
    [SwaggerOperation("Fetches all hours")]
    public async Task<IEnumerable<Hours>> Get()
    {
        var user = await this.GetUser(this._keyVaultService);

        return await _simplicateService.GetHours(user.Environment, user.Key, user.Secret);
    }

}
