using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Simplicator.Services;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[Produces("application/json")]
//[ApiExplorerSettings(IgnoreApi = true)]

public class HoursAfterController(ILogger<HoursAfterController> logger, IServiceProvider serviceProvider) : ControllerBase
{
    private readonly ILogger<HoursAfterController> _logger = logger;

    private readonly SimplicateService _simplicateService = serviceProvider
           .GetRequiredService<SimplicateService>();

    [HttpGet(template: "hoursafter", Name = "GetHoursAfter")]
    [EnableQuery]
    [SwaggerOperation("Fetches all hours after a specified date")]
    public async Task<IActionResult> Get([FromQuery] int? top, [FromQuery] int? skip, [FromQuery] DateTimeOffset date)
    {
        try
        {
            var user = this.GetUser();

            var hours = top.HasValue ? await _simplicateService.GetHourPageAfter(user.Environment, user.Key, user.Secret, date, top.HasValue ? top.Value : 100, skip.HasValue ? skip.Value : 0)
                : await _simplicateService.GetHoursAfter(user.Environment, user.Key, user.Secret, date);

            if (hours != null && hours.Any())
            {
                var json = JsonSerializer.Serialize(hours.Select(a => a.ToSimplicatorHours()));
                return Content(json, "application/json");

            }
            else
            {
                return NotFound("No hours found.");
            }
        }
        catch (Exception ex)
        {
            // Log the exception as needed
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet(template: "hoursafter/count", Name = "GetHoursAfterCount")]
    [SwaggerOperation("Fetches the total count of hours after a date")]
    public async Task<int> GetCount([FromQuery] DateTimeOffset date)
    {
        var user = this.GetUser();

        return await _simplicateService.GetHourPageCountAfter(user.Environment, user.Key, user.Secret, date);
    }

}
