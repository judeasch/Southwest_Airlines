using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Southwest_Airlines.Data.Models;
using Southwest_Airlines.Models;
using System;

namespace Southwest_Airlines.Controllers
{
    public class FlightsController : Controller
    {
        private readonly FastpassContext _context; // dbcontext allows to perform crud operations on database
        private Flight _flight; // gets set in Detail and is used to create a seat in UpdateSeat

        public FlightsController(FastpassContext context)
        {
            _context = context;
        }

        // Will list available flights
        public IActionResult Index()
        {
            return View();
        }

        // Shows seat map for selected flight
        public IActionResult Detail(int id)
        {
            _flight = _context.Set<Flight>().Find(id);
            var seats = _context.Seats.Where(s => s.FlightId == id).ToList();

            var viewModel = new FlightModel(_flight, seats);

            return View("Detail", viewModel);
        }

        //[HttpPost]
        //public IActionResult UpdateSeat(string seatNum)
        //{
        //    Dictionary<string, int> letterValues = new Dictionary<string, int>()
        //    {
        //        { "A", 0 },
        //        { "B", 1 },
        //        { "C", 2 },
        //        { "D", 3 },
        //        { "E", 4 },
        //        { "F", 5 }
        //    };
        //    var offsetValue = letterValues[seatNum[1].ToString()];
        //    var seatNumFirst = Convert.ToInt32(seatNum[0]);
        //    var seatNumInt = (seatNumFirst - 1) * 

        //    var numOfSeats = _flight.NumberOfSeats;
            

        //}
    }
}
