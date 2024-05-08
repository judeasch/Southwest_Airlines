using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Southwest_Airlines.Models;
using Microsoft.AspNetCore.Authorization;

namespace Southwest_Airlines.Controllers
{
    // Shows views for the landing page (and temporary admin page)
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Index()
        {
            return View();
        }

        // show Admin.cshtml, a placeholder page to test admin function
        [Authorize(Roles = "Admin")]
        public ViewResult Admin()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult Success()
        {
            return View("~/Views/Shared/_Success.cshtml"); // redirect to Success page
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
