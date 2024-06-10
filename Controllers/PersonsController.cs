using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class PersonsController(SimplicateService simplicateService) : ControllerBase
{
    [HttpGet]
    [EnableQuery]
    public async Task<IEnumerable<Person>> Get()
    {
        var user = this.GetUser();

        return await simplicateService.GetPersons(user.Environment, user.Key, user.Secret);
    }
}
