using Microsoft.AspNetCore.Mvc;
using NetCore.DI.Services.Example;

namespace NetCore.DI.WebAPI.Example.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SingletonController : ControllerBase
    {
        private readonly ISingletonDateService _singletonDateService;

        public SingletonController(
                 ISingletonDateService singletonDateService
            )
        {
            _singletonDateService = singletonDateService;
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
