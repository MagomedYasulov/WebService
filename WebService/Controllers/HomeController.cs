using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Страница отправки сообщений
        /// </summary>
        /// <returns></returns>
        [HttpGet("producer")]
        public IActionResult Producer()    
        {
            return View();
        }

        /// <summary>
        /// Страница получения сообщения
        /// </summary>
        /// <returns></returns>
        [HttpGet("consumer")]
        public IActionResult Consumer()
        {
            return View();
        }

        /// <summary>
        /// Страница просмотра сообщений за последние 10 мин
        /// </summary>
        /// <returns></returns>
        [HttpGet("browser")]
        public IActionResult Browser()
        {
            return View();
        }
    }
}
