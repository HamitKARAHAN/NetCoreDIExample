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

        public ScopedController(
                 IScopedDateService scopedDateService
            )
        {
            _scopedDateService = scopedDateService;
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
