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
public class DocumentTypesController : ControllerBase
{
    private readonly ILogger<DocumentTypesController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public DocumentTypesController(ILogger<DocumentTypesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();
        
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all document types")]
    public async Task<IEnumerable<DocumentType>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetDocumentTypes(user.Environment, user.Key, user.Secret);
    }

}
