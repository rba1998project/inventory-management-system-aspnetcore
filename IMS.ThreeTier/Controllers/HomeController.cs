using IMS.WEB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IMS.WEB.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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
            var exceptionFeature =
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                _logger.LogError(
                    exceptionFeature.Error,
                    "Unhandled exception occurred. User: {User}, Path: {Path}, Method: {Method}",
                    User?.Identity?.Name ?? "Anonymous",
                    exceptionFeature.Path,
                    HttpContext.Request.Method);
            }

            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(model);
        }
    }
}
