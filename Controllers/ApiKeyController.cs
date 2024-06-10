using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Simplicator.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Simplicator.Controllers
{
    public class ApiKeyRequest
    {
        [Required]
        public string ApiKey { get; set; } = null!;

        [Required]
        public string ApiSecret { get; set; } = null!;

        [Required]
        public string Environment { get; set; } = null!;
    }

    [ApiController]
    [Route("api/v2/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ApiKeyController(ILogger<ApiKeyController> logger) : ControllerBase
    {
        private readonly ILogger<ApiKeyController> _logger = logger;

        [HttpGet(Name = "GetApiKey")]
        [SwaggerOperation("Calculates an API Key")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<string> Get([FromQuery] ApiKeyRequest apiKeyRequest)
        {
            try
            {
                string apiKeyValue = $"{apiKeyRequest.ApiKey}:{apiKeyRequest.ApiSecret}@{apiKeyRequest.Environment}".EncodeBase64();
                return Ok(apiKeyValue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating the API key.");
                ModelState.AddModelError(string.Empty, "An error occurred while generating the API key.");
                return BadRequest(ModelState);
            }
        }
    }
}
