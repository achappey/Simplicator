using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/hrm/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;

    private readonly SimplicateService _simplicateService;

    public EmployeeController(ILogger<EmployeeController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetEmployees")]
    [EnableQuery]
    [Tags("HRM")]
    [SwaggerOperation("Fetches all employees")]
    public async Task<IEnumerable<Employee>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetEmployees(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "{id}/hours", Name = "GetEmployeeHours")]
    [Tags("HRM")]
    [EnableQuery]
    [SwaggerOperation("Fetches all employee hours")]
    public async Task<IEnumerable<Hours>> GetByEmployee([FromRoute] string id)
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetEmployeeHours(user.Environment, user.Key, user.Secret, id);
    }
    
}
