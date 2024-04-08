using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Quizlo.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("secure")]
        public IActionResult SecureHello()
        {
            return Ok("Hello, world!");
        }

        [HttpGet("unsecure")]
        [AllowAnonymous]
        public IActionResult UnSecureHello()
        {
            return Ok("Hello, world!");
        }
    }
}

