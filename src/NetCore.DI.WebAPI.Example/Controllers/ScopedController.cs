using Microsoft.AspNetCore.Mvc;
using NetCore.DI.Services.Example;
using NetCore.DI.WebAPI.Example.Models;

namespace NetCore.DI.WebAPI.Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScopedController : ControllerBase
    {
        private readonly IScopedDateService _scopedDateService;
        private readonly ILogger<ScopedController> _logger;

        public ScopedController(
                 IScopedDateService scopedDateService,
                 ILogger<ScopedController> logger
            )
        {
            _scopedDateService = scopedDateService;
            _logger=logger;
            _logger.LogInformation("Scoped Controller is running...");
        }

        [HttpGet]
        public async Task<IActionResult> Scoped([FromServices] IScopedDateService scopedDateService)
        {
            return Ok(new DateTimeDTO()
            {
                DateTime1 = await _scopedDateService.GetDateTime,
                DateTime2 = await scopedDateService.GetDateTime
            });
        }
    }
}
