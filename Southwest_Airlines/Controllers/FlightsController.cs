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
        private UserManager<ApplicationUser> _userManager;

        public FlightsController(FastpassContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Will list available flights
        [HttpGet]
        public IActionResult Index(string? id)
        {
            if (id != null) // check if an employee is accessing their assigned flights
            {
                try
                {
                    var employee = _context.Employees.Where(e => e.UserId == id).Include(e => e.Flights).FirstOrDefault();

                    FlightListModel employeeFlightListModel = new FlightListModel(employee.Flights, true); // set IsEmployee to true

                    return View(employeeFlightListModel);
                }
                catch
                {
                    ModelState.AddModelError("Error", "The employee was not found.");
                    return RedirectToAction("Index", "Home");
                }
            }
            try
            {
                var flights = _context.Flights.ToList();
                FlightListModel flightListModel = new FlightListModel(flights, false); // set IsEmployee to false

                return View(flightListModel);
            }
            catch
            {
                ModelState.AddModelError("Error", "Could not find flights.");
                return RedirectToAction("Index", "Home");
            }
        }

        // Shows seat map for selected flight
        [HttpGet]
        public IActionResult Seats(int id)
        {
            _flight = _context.Set<Flight>().Find(id);
            if (_flight != null)
            {
                var seats = _context.Seats.Where(s => s.FlightId == id).ToList();

                FlightModel viewModel = new FlightModel(_flight, seats);

                return View("Seats", viewModel);
            }
            
            ModelState.AddModelError("Error", "The flight was not found.");
            return Redirect(Request.Headers.Referer.ToString());
        }

        // get a list of passengers for a flight for employee view
        [HttpGet]
        public IActionResult Passengers(int id)
        {
            _flight = _context.Set<Flight>().Find(id);
            if (_flight != null)
            {
                var tickets = _context.Tickets.Where(t => t.FlightId == _flight.FlightId).ToList(); // get a list of tickets for particular flight
                var customers = _context.Customers.ToList();
                var seats = _context.Seats.ToList();
                
                var fastpasses = _context.Fastpasses.ToList();

                PassengerModel viewModel = new PassengerModel(_flight, customers, seats, tickets, fastpasses);
                return View("Passengers", viewModel);
            }

            ModelState.AddModelError("Error", "The flight was not found.");
            return Redirect(Request.Headers.Referer.ToString());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSeat(string seatNum, int flightId)
        {
            try
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
                var seatNumInt = (row * 6) - offsetValue; // get the seat number as an int

                if (_flight != null && _flight.TotalNumberOfSeats > 0) // check if there are still seats available
                {
                    Seat seat = new Seat(seatNumInt.ToString(), _flight.FlightId);
                    _context.Seats.Add(seat);
                    _context.SaveChanges(); // save Seat changes here so that we can create a new Ticket

                    var user = await _userManager.GetUserAsync(User);
                    var userId = user.Id;
                    var customer = _context.Customers
                        .Where(u => u.UserId == userId)
                        .FirstOrDefault();

                    if (customer != null)
                    {
                        Ticket ticket = new Ticket(seat.SeatId, _flight.FlightId, customer.CustomerId);
                        _context.Tickets.Add(ticket);

                        var numOfSeats = _flight.TotalNumberOfSeats - 1; // update number of available seats on the flight
                        _flight.TotalNumberOfSeats = numOfSeats;
                        _context.SaveChanges();

                        return RedirectToAction("Index", "Flights");
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "The customer was not found.");
                        return RedirectToAction("Index", "Flights");
                    }                   
                }

                ModelState.AddModelError("Error", "The flight was not found or there are no seats available.");
                return RedirectToAction("Index", "Flights");
            }
            catch
            {
                ModelState.AddModelError("Error", "There was an error processing your selection. It's possible the seat you selected is invalid.");
                return RedirectToAction("Index", "Flights");
            }
        }
    }
}
