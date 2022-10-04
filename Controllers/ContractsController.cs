using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ContractsController : ControllerBase
{
    private readonly ILogger<ContractsController> _logger;

    private readonly SimplicateService _simplicateService;

    public ContractsController(ILogger<ContractsController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet]
    [EnableQuery]
    [Tags("CRM")]
    [SwaggerOperation("Fetches all contracts")]
    public async Task<IEnumerable<Contract>> Get()
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.GetContracts(user.Environment, user.Key, user.Secret);
    }
}
