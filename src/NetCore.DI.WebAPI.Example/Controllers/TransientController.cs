using Microsoft.AspNetCore.Mvc;
using NetCore.DI.Services.Example;
using Newtonsoft.Json;

namespace NetCore.DI.WebAPI.Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransientController : ControllerBase
    {
        private readonly ITransientDateService _transientDateService;

        public TransientController(
                 ITransientDateService transientDateService
            )
        {
            _transientDateService = transientDateService;
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
