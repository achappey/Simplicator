using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly ILogger<PersonsController> _logger;

    private readonly SimplicateService _simplicateService;

    public PersonsController(ILogger<PersonsController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetPersons")]
    [EnableQuery]
    [Tags("CRM")]
    public async Task<IEnumerable<Person>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetPersons(user.Environment, user.Key, user.Secret);
    }
}
