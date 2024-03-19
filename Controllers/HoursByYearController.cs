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

public class HoursByYearController : ControllerBase
{
    private readonly ILogger<HoursByYearController> _logger;

    private readonly SimplicateService _simplicateService;

    public HoursByYearController(ILogger<HoursByYearController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _simplicateService = serviceProvider
           .GetRequiredService<SimplicateService>();

    }

    [HttpGet(template: "hoursbyyear", Name = "GetHoursByYear")]
    [EnableQuery]
    [SwaggerOperation("Fetches all hours by year")]
    public async Task<IActionResult> Get([FromQuery] int? top, [FromQuery] int? skip, [FromQuery] int year)
    {
        try
        {
            var user = this.GetUser();

            var hours = top.HasValue ? await _simplicateService.GetHourPageByYear(user.Environment, user.Key, user.Secret, year, top.HasValue ? top.Value : 100, skip.HasValue ? skip.Value : 0)
                : await _simplicateService.GetHoursByYear(user.Environment, user.Key, user.Secret, year);

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

    [HttpGet(template: "hoursbyyear/count", Name = "GetHoursYearCount")]
    [SwaggerOperation("Fetches the total count of hours by year")]
    public async Task<int> GetCount([FromQuery] int year)
    {
        var user = this.GetUser();

        return await _simplicateService.GetHourPageCountByYear(user.Environment, user.Key, user.Secret, year);
    }

}
