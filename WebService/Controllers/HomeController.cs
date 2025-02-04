using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [HttpGet("producer")]
        public IActionResult Producer()
        
        {
            return View();
        }

        [HttpGet("consumer")]
        public IActionResult Consumer()
        {
            return View();
        }

        [HttpGet("browser")]
        public IActionResult Browser()
        {
            return View();
        }
    }
}
