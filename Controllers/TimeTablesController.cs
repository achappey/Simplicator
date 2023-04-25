using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[Produces("application/json")]
[ApiExplorerSettings(IgnoreApi = true)]

public class TimeTablesController : ControllerBase
{
    private readonly ILogger<TimeTablesController> _logger;

    private readonly SimplicateService _simplicateService;

    public TimeTablesController(ILogger<TimeTablesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        
         _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

    }

    [HttpGet(template: "timetables", Name = "GetTimeTables")]
    [EnableQuery]
    [SwaggerOperation("Fetches all timetables")]
    public async Task<IEnumerable<TimeTable>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetTimeTables(user.Environment, user.Key, user.Secret);
    }

}
