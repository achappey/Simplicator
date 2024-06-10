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
public class MyOrganizationsController(ILogger<MyOrganizationsController> logger, IServiceProvider serviceProvider) : ControllerBase
{
    private readonly ILogger<MyOrganizationsController> _logger = logger;

    private readonly SimplicateService _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

    [HttpGet]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all my organizations")]
    public async Task<IEnumerable<MyOrganization>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetMyOrganizations(user.Environment, user.Key, user.Secret);
    }
}
