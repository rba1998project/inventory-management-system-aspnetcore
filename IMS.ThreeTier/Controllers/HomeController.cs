using Microsoft.AspNetCore.Mvc;

namespace IMS.WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
