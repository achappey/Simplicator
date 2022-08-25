using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[ApiExplorerSettings(IgnoreApi = true)]
public class MessagesController : ControllerBase
{
    private readonly ILogger<MessagesController> _logger;

    private readonly SimplicateService _simplicateService;

    public MessagesController(ILogger<MessagesController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpGet(template: "messages", Name = "GetMessages")]
    [EnableQuery]
    [SwaggerOperation("Fetches all messages")]
    public async Task<IEnumerable<Message>> Get()
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.GetMessages(user.Environment, user.Key, user.Secret);
    }

}