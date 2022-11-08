using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class PersonsController : ControllerBase
{
    private readonly ILogger<PersonsController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public PersonsController(ILogger<PersonsController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
          .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    public async Task<IEnumerable<Person>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetPersons(user.Environment, user.Key, user.Secret);
    }
}
