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

public class CrmController(SimplicateService simplicateService) : ControllerBase
{
    [HttpGet(template: "person", Name = "GetPersons")]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all persons")]
    [ProducesResponseType(typeof(IEnumerable<Person>), 200)]
    public async Task<IEnumerable<Person>> GetPersons()
    {
        var user = this.GetUser();

        return await simplicateService.GetPersons(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "organization", Name = "GetOrganizations")]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all organizations")]
    public async Task<IEnumerable<Organization>> GetOrganizations()
    {
        var user = this.GetUser();

        return await simplicateService.GetOrganizations(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "myorganization", Name = "GetMyOrganizations")]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all my organizations")]
    public async Task<IEnumerable<Organization>> GetMyOrganizations()
    {
        var user = this.GetUser();

        return await simplicateService.GetOrganizations(user.Environment, user.Key, user.Secret);
    }
}
