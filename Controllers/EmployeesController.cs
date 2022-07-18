using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly ILogger<EmployeesController> _logger;

    private readonly SimplicateService _simplicateService;

    public EmployeesController(ILogger<EmployeesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetEmployees")]
    [EnableQuery]
    [Tags("HRM")]
    public async Task<IEnumerable<Employee>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetEmployees(user.Environment, user.Key, user.Secret);
    }
}
