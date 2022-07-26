using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/invoices/[controller]")]
public class VatClassController : ControllerBase
{
    private readonly ILogger<VatClassController> _logger;

    private readonly SimplicateService _simplicateService;

    public VatClassController(ILogger<VatClassController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetVatClasses")]
    [EnableQuery]
    [Tags("Invoices")]
    [SwaggerOperation("Fetches all vat classes")]
    public async Task<IEnumerable<VatClass>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetVatClasses(user.Environment, user.Key, user.Secret);
    }
}
