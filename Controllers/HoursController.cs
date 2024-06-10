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

public class HoursController(ILogger<HoursController> logger, IServiceProvider serviceProvider) : ControllerBase
{
    private readonly ILogger<HoursController> _logger = logger;

    private readonly SimplicateService _simplicateService = serviceProvider
           .GetRequiredService<SimplicateService>();

    [HttpGet(template: "hours", Name = "GetHours")]
    [EnableQuery]
    [SwaggerOperation("Fetches all hours")]
    public async Task<IActionResult> Get([FromQuery] int? top, [FromQuery] int? skip)
    {
        try
        {
            var user = this.GetUser();

            var hours = top.HasValue ? await _simplicateService.GetHourPage(user.Environment, user.Key, user.Secret, top.HasValue ? top.Value : 100, skip.HasValue ? skip.Value : 0)
                : await _simplicateService.GetHours(user.Environment, user.Key, user.Secret);

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

    [HttpGet(template: "hours/count", Name = "GetHoursCount")]
    [SwaggerOperation("Fetches the total count of hours")]
    public async Task<int> GetCount()
    {
        var user = this.GetUser();

        return await _simplicateService.GetHourCount(user.Environment, user.Key, user.Secret);
    }

}
