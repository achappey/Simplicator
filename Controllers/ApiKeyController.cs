using Microsoft.AspNetCore.Mvc;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class ApiKeyController : ControllerBase
{
    private readonly ILogger<ApiKeyController> _logger;

    public ApiKeyController(ILogger<ApiKeyController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetApiKey")]
    [SwaggerOperation("Calculates an API Key")]
    public async Task<ActionResult<string>> Get(string apiKey, string apiSecret, string environment)
    {
        if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret) || string.IsNullOrEmpty(environment))
        {
            ModelState.AddModelError(string.Empty, "One or more input parameters are missing or empty.");
            return BadRequest(ModelState);
        }

        try
        {
            string apiKeyValue = GenerateApiKey(apiKey, apiSecret, environment);
            return Ok(apiKeyValue);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while generating the API key.");
            ModelState.AddModelError(string.Empty, "An error occurred while generating the API key.");
            return BadRequest(ModelState);
        }
    }

    private string GenerateApiKey(string apiKey, string apiSecret, string environment)
    {
        return $"{apiKey}:{apiSecret}@{environment}".EncodeBase64();
    }

}