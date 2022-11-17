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
public class DocumentsController : ControllerBase
{
    private readonly ILogger<DocumentsController> _logger;

    private readonly SimplicateService _simplicateService;

    public DocumentsController(ILogger<DocumentsController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all documents")]
    public async Task<IEnumerable<Document>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetDocuments(user.Environment, user.Key, user.Secret);
    }

}
