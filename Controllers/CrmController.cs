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
public class CrmController : ControllerBase
{
    private readonly ILogger<CrmController> _logger;

    private readonly SimplicateService _simplicateService;

    public CrmController(ILogger<CrmController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(template: "person", Name = "GetPersons")]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all persons")]
    [ProducesResponseType(typeof(IEnumerable<Person>), 200)]
    public async Task<IEnumerable<Person>> GetPersons()
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.GetPersons(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "organization", Name = "GetOrganizations")]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all organizations")]
    public async Task<IEnumerable<Organization>> GetOrganizations()
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.GetOrganizations(user.Environment, user.Key, user.Secret);
    }
}
