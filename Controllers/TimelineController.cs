using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public class TimelineController : ControllerBase
{
    private readonly ILogger<TimelineController> _logger;

    private readonly SimplicateService _simplicateService;

    public TimelineController(ILogger<TimelineController> logger, SimplicateService simplicateService)
    {
        _logger = logger;
        _simplicateService = simplicateService;
    }

    [HttpPost(template: "message", Name = "AddMessage")]
    [Tags("Timeline")]
    [SwaggerOperation("Add a new message")]
    public async Task<Message> AddMessage([FromBody] NewMessage message)
    {
        var user = this.HttpContext.GetUser();

        return await _simplicateService.AddMessage(user.Environment, user.Key, user.Secret, message);
    }

}