using Microsoft.AspNetCore.Mvc;
using Simplicate.NET.Models;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class TimelineController : ControllerBase
{
    private readonly ILogger<TimelineController> _logger;

    private readonly SimplicateService _simplicateService;

    private readonly KeyVaultService _keyVaultService;

    public TimelineController(ILogger<TimelineController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;

        _simplicateService = serviceProvider
            .GetRequiredService<SimplicateService>();

        _keyVaultService = serviceProvider
          .GetService<KeyVaultService>() ??
            null!;
    }

    [HttpPost(template: "message", Name = "AddMessage")]
    [Tags("Timeline")]
    [SwaggerOperation("Add a new message")]
    public async Task<Message> AddMessage([FromBody] NewMessage message)
    {
        var user = await this.HttpContext.GetUser(this._keyVaultService);

        return await _simplicateService.AddMessage(user.Environment, user.Key, user.Secret, message);
    }

}
