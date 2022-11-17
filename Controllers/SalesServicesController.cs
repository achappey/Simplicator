using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class SalesServicesController : ControllerBase
{
    private readonly ILogger<SalesServicesController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public SalesServicesController(ILogger<SalesServicesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all sales services")]
    public async Task<IEnumerable<SalesService>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetSalesServices(user.Environment, user.Key, user.Secret);
    }
}