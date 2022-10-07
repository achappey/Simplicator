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
public class SalesProgressesController : ControllerBase
{
    private readonly ILogger<SalesProgressesController> _logger;

    private readonly SimplicateService _simplicateService;

    private readonly KeyVaultService _keyVaultService;

    public SalesProgressesController(ILogger<SalesProgressesController> logger, IServiceProvider serviceProvider)
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
    [SwaggerOperation("Fetches all sales progresses")]
    public async Task<IEnumerable<SalesProgress>> Get()
    {
        var user = await this.HttpContext.GetUser(this._keyVaultService);

        return await _simplicateService.GetSalesProgresses(user.Environment, user.Key, user.Secret);
    }

}
