using Microsoft.AspNetCore.Mvc;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
//[ApiExplorerSettings(IgnoreApi = true)]
public class ApiKeyController : ControllerBase
{
    private readonly ILogger<ApiKeyController> _logger;

    public ApiKeyController(ILogger<ApiKeyController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetApiKey")]
    [SwaggerOperation("Calculates an API Key")]
    public string Get(string apiKey, string apiSecret, string environment)
    {
        return string.Format("{0}:{1}@{2}", apiKey, apiSecret, environment).EncodeBase64();
    }
}
