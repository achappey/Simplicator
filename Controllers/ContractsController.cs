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
public class ContractsController(SimplicateService simplicateService) : ControllerBase
{
    [HttpGet]
    [EnableQuery]
    [Tags("HRM")]
    [SwaggerOperation("Fetches all contracts")]
    public async Task<IEnumerable<Contract>> GetContracts()
    {
        var user = this.GetUser();

        return await simplicateService.GetContracts(user.Environment, user.Key, user.Secret);
    }
}
