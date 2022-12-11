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
public class OrganizationsController : ControllerBase
{
    private readonly ILogger<OrganizationsController> _logger;

    private readonly SimplicateService _simplicateService;

    public OrganizationsController(ILogger<OrganizationsController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();
    }

    [HttpGet]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all organizations")]
    public async Task<IEnumerable<Organization>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetOrganizations(user.Environment, user.Key, user.Secret);
    }
}
