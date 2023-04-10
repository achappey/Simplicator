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
public class InvoiceStatusesController : ControllerBase
{
    private readonly ILogger<InvoiceStatusesController> _logger;

    private readonly SimplicateService _simplicateService;

    public InvoiceStatusesController(ILogger<InvoiceStatusesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all invoice statuses")]
    public async Task<IEnumerable<InvoiceStatus>> Get()
    {
        var user = this.GetUser();

        return await _simplicateService.GetInvoiceStatuses(user.Environment, user.Key, user.Secret);
    }

}
