using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Southwest_Airlines.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Southwest_Airlines.Models;
using System;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Southwest_Airlines.Controllers
{
    [Authorize]
    public class FlightsController : Controller
    {
        private readonly FastpassContext _context; // dbcontext allows to perform crud operations on database
        private Flight _flight; // gets set in Detail and is used to create a seat in UpdateSeat
        private UserManager<IdentityUser> _userManager;

        public FlightsController(FastpassContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Will list available flights
        public IActionResult Index()
        {
            var flights = _context.Flights.ToList();
            FlightListModel flightListModel = new FlightListModel(flights);

            return View(flightListModel);
        }

        // Shows seat map for selected flight
        [HttpGet]
        public IActionResult Detail(int id)
        {
            _flight = _context.Set<Flight>().Find(id);
            if (_flight != null)
            {
                var seats = _context.Seats.Where(s => s.FlightId == id).ToList();

                FlightModel viewModel = new FlightModel(_flight, seats);

                return View("Detail", viewModel);
            }
            
            return View("Index");
        }

        [HttpPost]
        public IActionResult UpdateSeat(string seatNum, int flightId)
        {
            Dictionary<string, int> letterValues = new Dictionary<string, int>()
            {
                { "A", 5 },
                { "B", 4 },
                { "C", 3 },
                { "D", 2 },
                { "E", 1 },
                { "F", 0 }
            };

            _flight = _context.Set<Flight>().Find(flightId);

            var offsetValue = letterValues[seatNum[seatNum.Length - 1].ToString()]; // get last char of seatNum, which is the letter
            var row = Convert.ToInt32(seatNum.Substring(0, seatNum.Length - 1)); // get the row number, so all chars except the letter
            var seatNumInt = (row * 6) - offsetValue;

            // _flight = _context.Set<Flight>().Find(flightId);

            if (_flight != null && _flight.TotalNumberOfSeats > 0)
            {
                Seat seat = new Seat(seatNumInt.ToString(), _flight.FlightId);
                _context.Seats.Add(seat);
                _context.SaveChanges(); // save Seat changes here so that we can create a new Ticket

                // var user = _userManager.GetUserAsync(User);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = _context.Customers
                    .Where(u => u.LoginId == userId)
                    .FirstOrDefault();

                if (customer != null)
                {
                    Ticket ticket = new Ticket(seat.SeatId, _flight.FlightId, customer.CustomerId);
                    _context.Tickets.Add(ticket);

                    var numOfSeats = _flight.TotalNumberOfSeats - 1;
                    _flight.TotalNumberOfSeats = numOfSeats;
                    _context.SaveChanges();
                }
                
                return RedirectToAction("Index", "Flights");
            }

            return RedirectToAction("Index", "Flights");
        }
    }
}
