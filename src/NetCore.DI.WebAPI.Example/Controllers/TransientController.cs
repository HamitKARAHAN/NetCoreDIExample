using Microsoft.AspNetCore.Mvc;
using NetCore.DI.Services.Example;
using NetCore.DI.WebAPI.Example.Models;

namespace NetCore.DI.WebAPI.Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransientController : ControllerBase
    {
        private readonly ITransientDateService _transientDateService;
        private readonly ILogger<TransientController> _logger;

        public TransientController(
                 ITransientDateService transientDateService, 
                 ILogger<TransientController> logger
            )
        {
            _transientDateService = transientDateService;
            _logger = logger;
            _logger.LogInformation("Transient Controller is running...");
        }

        [HttpGet]
        public async Task<IActionResult> Transient([FromServices] ITransientDateService transientDateService)
        {
            return Ok(new DateTimeDTO()
            {
                DateTime1 = await _transientDateService.GetDateTime,
                DateTime2 = await transientDateService.GetDateTime
            });
        }
    }
}
