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

public class LeavesController : ControllerBase
{
    private readonly ILogger<LeavesController> _logger;

    private readonly SimplicateService _simplicateService;

    // Use constructor injection to directly inject SimplicateService
    public LeavesController(ILogger<LeavesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    /// <summary>
    /// Fetches all leaves
    /// </summary>
    /// <returns>A list of leaves</returns>
    [HttpGet(template: "leaves", Name = "GetLeaves")]
    [EnableQuery]
    [SwaggerOperation("Fetches all leaves")]
    public async Task<IEnumerable<Leave>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetLeaves(user.Environment, user.Key, user.Secret);
    }

}
