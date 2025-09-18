using Microsoft.AspNetCore.Mvc;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Index - show home page
        public IActionResult Index()
        {
            return View();
        }
    }
}