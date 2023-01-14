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

    

    public MessagesController(ILogger<MessagesController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();
    }

    [HttpGet(template: "messages", Name = "GetMessages")]
    [EnableQuery]
    [SwaggerOperation("Fetches all messages")]
    public async Task<IEnumerable<Message>> Get()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetAllMessages(user.Environment, user.Key, user.Secret);
    }

    [HttpGet(template: "lastweek", Name = "LastWeek")]
    [EnableQuery]
    [SwaggerOperation("Fetches last week messages")]
    public async Task<IEnumerable<Message>> LastWeek()
    {
        var user = await this.GetUser();

        return await _simplicateService.GetMessagesLastWeek(user.Environment, user.Key, user.Secret);
    }

}
