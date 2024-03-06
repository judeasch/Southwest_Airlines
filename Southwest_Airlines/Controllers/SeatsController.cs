using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Southwest_Airlines.Data.Models;

namespace Southwest_Airlines.Controllers
{
    [Authorize]
    public class SeatsController : Controller
    {
        private readonly FastpassContext _context;

        public SeatsController(FastpassContext context)
        { 
            _context = context;
        }
        public IActionResult Index(int id)
        {
            return View();
        }

    }
}
