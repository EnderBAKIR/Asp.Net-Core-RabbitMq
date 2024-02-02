using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RabbitMQExelCreat_WEB.APP.Controllers
{
    public class ProductController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
