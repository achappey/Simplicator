using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganizationsController : ControllerBase
{
    private readonly ILogger<OrganizationsController> _logger;

    private readonly SimplicateService _simplicateService;

    public OrganizationsController(ILogger<OrganizationsController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetOrganizations")]
    [EnableQuery]
    [Tags("CRM")]
    public async Task<IEnumerable<Organization>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetOrganizations(user.Environment, user.Key, user.Secret);
    }
}
