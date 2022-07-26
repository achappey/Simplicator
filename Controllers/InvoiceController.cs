using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/invoices/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly ILogger<InvoiceController> _logger;

    private readonly SimplicateService _simplicateService;

    public InvoiceController(ILogger<InvoiceController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetInvoices")]
    [EnableQuery]
    [Tags("Invoices")]
    [SwaggerOperation("Fetches all invoices")]
    public async Task<IEnumerable<Invoice>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetInvoices(user.Environment, user.Key, user.Secret);
    }

}
