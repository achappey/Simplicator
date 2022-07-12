using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoicesController : ControllerBase
{
    private readonly ILogger<InvoicesController> _logger;

    private readonly SimplicateService _simplicateService;

    public InvoicesController(ILogger<InvoicesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(Name = "GetInvoices")]
    [EnableQuery]
    public async Task<IEnumerable<Invoice>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetInvoices(user.Environment, user.Key, user.Secret);
    }
}
