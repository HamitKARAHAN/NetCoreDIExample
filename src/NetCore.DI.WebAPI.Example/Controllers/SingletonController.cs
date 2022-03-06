using Microsoft.AspNetCore.Mvc;
using NetCore.DI.Services.Example;
using NetCore.DI.WebAPI.Example.Models;

namespace NetCore.DI.WebAPI.Example.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SingletonController : ControllerBase
    {
        private readonly ISingletonDateService _singletonDateService;
        private readonly ILogger<SingletonController> _logger;

        public SingletonController(
                 ISingletonDateService singletonDateService,
                 ILogger<SingletonController> logger
            )
        {
            _singletonDateService = singletonDateService;
            _logger = logger;
            _logger.LogInformation("Singleton Controller is running...");
        }

        [HttpGet]
        public async Task<IActionResult> Singleton([FromServices] ISingletonDateService singletonDateService)
        {
            return Ok(new DateTimeDTO()
            {
                DateTime1 = await _singletonDateService.GetDateTime,
                DateTime2 = await singletonDateService.GetDateTime
            });
        }
    }
}
