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
[ApiExplorerSettings(IgnoreApi = true)]

public class InvoicesController(ILogger<InvoicesController> logger, SimplicateService simplicateService) : ControllerBase
{
    private readonly ILogger<InvoicesController> _logger = logger;

    private readonly SimplicateService _simplicateService = simplicateService;

    [HttpGet(template: "invoice", Name = "GetInvoices")]
    [EnableQuery]
    [Tags("Invoices")]
    [SwaggerOperation("Fetches all invoices")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IEnumerable<Invoice>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetInvoices(user.Environment, user.Key, user.Secret);
    }

}
