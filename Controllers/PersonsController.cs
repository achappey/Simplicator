using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class PersonsController : ControllerBase
{
    private readonly ILogger<PersonsController> _logger;

    private readonly SimplicateService _simplicateService;

    public PersonsController(ILogger<PersonsController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet]
    [EnableQuery]
    public async Task<IEnumerable<Person>> Get()
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.GetPersons(user.Environment, user.Key, user.Secret);
    }
}
