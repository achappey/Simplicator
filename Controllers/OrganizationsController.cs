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
[Consumes("application/json")]
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
    [ApiExplorerSettings(IgnoreApi = true)]
    [SwaggerOperation("Fetches all organizations")]
    public async Task<IEnumerable<Organization>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetOrganizations(user.Environment, user.Key, user.Secret);
    }
    
    [HttpGet(template: "organization/{id}", Name = "GetOrganization")]
    [EnableQuery]
    [SwaggerOperation("Fetches organization for the given organization id")]
    public async Task<Organization?> GetOrganization([FromRoute] string id)
    {
        var user = await this.GetUser();

        return await _simplicateService.GetOrganization(user.Environment, user.Key, user.Secret, id);
    }

    [HttpPut(template: "organization/{id}", Name = "UpdateOrganization")]
    [SwaggerOperation("Updates an organization for the given id")]
    public async Task<Organization> UpdateOrganization([FromRoute] string id, [FromBody] Organization organization)
    {
        var user = await this.GetUser();

        return await _simplicateService.UpdateOrganization(user.Environment, user.Key, user.Secret, id, organization);
    }
}
