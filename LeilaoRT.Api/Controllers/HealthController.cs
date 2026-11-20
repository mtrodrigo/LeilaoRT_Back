using Microsoft.AspNetCore.Mvc;

namespace LeilaoRT.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok("Api is running");
        }
    }
}
