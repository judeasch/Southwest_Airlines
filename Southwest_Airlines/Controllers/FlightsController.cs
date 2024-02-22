using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Southwest_Airlines.Data.Models;
using Southwest_Airlines.Models;
using System;

namespace Southwest_Airlines.Controllers
{
    public class FlightsController : Controller
    {
        private readonly FastpassContext _context;

        public FlightsController(FastpassContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var flight = _context.Set<Flight>().Find(id);
            var seats = _context.Seats.Where(s => s.FlightId == id).ToList();

            var viewModel = new FlightModel(flight, seats);

            return View("Detail", viewModel);
        }
    }
}
