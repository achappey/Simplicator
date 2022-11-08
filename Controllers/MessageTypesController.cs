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
public class MessageTypesController : ControllerBase
{
    private readonly ILogger<MessageTypesController> _logger;

    private readonly SimplicateService _simplicateService;

    

    public MessageTypesController(ILogger<MessageTypesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
       .GetRequiredService<SimplicateService>();

        
    }

    [HttpGet]
    [EnableQuery]
    [SwaggerOperation("Fetches all message types")]
    public async Task<IEnumerable<MessageType>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetMessageTypes(user.Environment, user.Key, user.Secret);
    }

}
