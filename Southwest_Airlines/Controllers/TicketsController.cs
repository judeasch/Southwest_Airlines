using Microsoft.AspNetCore.Mvc;
using Southwest_Airlines.Data.Models;
using Southwest_Airlines.Models;

namespace Southwest_Airlines.Controllers
{
    public class TicketsController : Controller
    {
        private readonly FastpassContext _context; // dbcontext allows to perform crud operations on database

        public TicketsController(FastpassContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string? id)
        {
            var customer = _context.Customers.Where(c => c.UserId == id).FirstOrDefault();
            var tickets = _context.Tickets.Where(t => t.CustomerId == customer.CustomerId).ToList();
            var flights = _context.Flights.ToList();
            var seats = _context.Seats.ToList();
            
            TicketListModel ticketListModel = new TicketListModel(tickets, flights, seats);

            return View("~/Views/Tickets/Index.cshtml", ticketListModel);
        }
    }
}
