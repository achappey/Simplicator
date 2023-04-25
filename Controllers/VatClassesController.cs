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
[Consumes("application/json")]
// TEMP
[ApiExplorerSettings(IgnoreApi = true)]

public class VatClassesController : ControllerBase
{
    private readonly ILogger<VatClassesController> _logger;

    private readonly SimplicateService _simplicateService;

    public VatClassesController(ILogger<VatClassesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;

        _simplicateService = simplicateService;
    }

    [HttpGet(template: "vatclass", Name = "GetVatClasses")]
    [EnableQuery]
    [Tags("Invoices")]
    [SwaggerOperation("Fetches all vat classes")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IEnumerable<VatClass>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetVatClasses(user.Environment, user.Key, user.Secret);
    }

}
