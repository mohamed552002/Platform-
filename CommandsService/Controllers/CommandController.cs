using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controller
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
            
        }
        [HttpPost]
        public IActionResult TestInboundConnection()
        {
            Console.WriteLine("DDDDD");
            return Ok("Inbound test");
        }
    }
}