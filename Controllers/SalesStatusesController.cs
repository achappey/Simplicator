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
public class SalesStatusesController(ILogger<SalesStatusesController> logger, IServiceProvider serviceProvider) : ControllerBase
{
    private readonly ILogger<SalesStatusesController> _logger = logger;

    private readonly SimplicateService _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all sales statuses")]
    public async Task<IEnumerable<SalesStatus>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetSalesStatuses(user.Environment, user.Key, user.Secret);
    }

}
