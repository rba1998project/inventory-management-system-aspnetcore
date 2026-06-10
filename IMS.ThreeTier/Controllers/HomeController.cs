using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.WEB.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin") || User.IsInRole("InventoryManager"))
                {
                    return RedirectToAction("Index", "Dashboard");
                }

            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
