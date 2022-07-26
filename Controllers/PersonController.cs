using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/crm/[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    private readonly SimplicateService _simplicateService;

    public PersonController(ILogger<PersonController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetPersons")]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all persons")]
    public async Task<IEnumerable<Person>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetPersons(user.Environment, user.Key, user.Secret);
    }
}
