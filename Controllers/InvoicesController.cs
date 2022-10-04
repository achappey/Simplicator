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
public class InvoicesController : ControllerBase
{
    private readonly ILogger<InvoicesController> _logger;

    private readonly SimplicateService _simplicateService;

    public InvoicesController(ILogger<InvoicesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(template: "invoice", Name = "GetInvoices")]
    [EnableQuery]
    [Tags("Invoices")]
    [SwaggerOperation("Fetches all invoices")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<IEnumerable<Invoice>> Get()
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.GetInvoices(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "vatclass", Name = "GetVatClasses")]
    [EnableQuery]
    [Tags("Invoices")]
    [SwaggerOperation("Fetches all vat classes")]
    public async Task<IEnumerable<VatClass>> GetVatClasses()
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.GetVatClasses(user.Environment, user.Key, user.Secret);
    }

    [HttpPost(template: "invoice", Name = "AddInvoice")]
    [Tags("Invoices")]
    [SwaggerOperation("Add a new invoice")]
    public async Task<Invoice> AddMessage([FromBody] NewInvoice invoice)
    {
        var user = await this.HttpContext.GetUser();

        return await _simplicateService.AddInvoice(user.Environment, user.Key, user.Secret, invoice);
    }

}
