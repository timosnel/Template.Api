using Microsoft.AspNetCore.Mvc;

namespace Name.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Hello world");
    }
}
