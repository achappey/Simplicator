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
public class HrmController : ControllerBase
{
    private readonly ILogger<HrmController> _logger;

    private readonly SimplicateService _simplicateService;

    public HrmController(ILogger<HrmController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();
    }

    [HttpGet(template: "employee", Name = "GetEmployees")]
    [EnableQuery]
    [Tags("HRM")]
    [SwaggerOperation("Fetches all employees")]
    public async Task<IEnumerable<Employee>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetEmployees(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "employee/{id}/hours", Name = "GetEmployeeHours")]
    [Tags("HRM")]
    [EnableQuery]
    [SwaggerOperation("Fetches all hours for the given employee id")]
    public async Task<IEnumerable<Hours>> GetByEmployee([FromRoute] string id)
    {
        var user = this.GetUser();

        return await _simplicateService.GetEmployeeHours(user.Environment, user.Key, user.Secret, id);
    }

}
