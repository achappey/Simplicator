using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/crm/[controller]")]
public class OrganizationController : ControllerBase
{
    private readonly ILogger<OrganizationController> _logger;

    private readonly SimplicateService _simplicateService;

    public OrganizationController(ILogger<OrganizationController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetOrganizations")]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all organizations")]
    public async Task<IEnumerable<Organization>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetOrganizations(user.Environment, user.Key, user.Secret);
    }
}
