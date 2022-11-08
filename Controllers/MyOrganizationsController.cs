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
public class MyOrganizationsController : ControllerBase
{
    private readonly ILogger<MyOrganizationsController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public MyOrganizationsController(ILogger<MyOrganizationsController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all my organizations")]
    public async Task<IEnumerable<MyOrganization>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetMyOrganizations(user.Environment, user.Key, user.Secret);
    }
}
