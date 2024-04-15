﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Southwest_Airlines.Data.Models;
using Southwest_Airlines.Models;

namespace Southwest_Airlines.Controllers
{
    public class FastpassesController : Controller
    {
        private readonly FastpassContext _context; // dbcontext allows to perform crud operations on database
        private Ticket _ticket;
        private Customer _customer;
        private Flight _flight;

        public FastpassesController(FastpassContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            _ticket = _context.Set<Ticket>().Find(id);
            _customer = _context.Customers
                .Where(u => u.CustomerId == _ticket.CustomerId)
                .FirstOrDefault();
            
            if (_ticket != null)
            {
                // create model w/ CustomerId and TicketId already set so they can be used in UpdateFastpass
                PaymentInfo paymentInfo = new PaymentInfo(_customer.CustomerId, _ticket.TicketId);

                return View("~/Views/PaymentInfo/Detail.cshtml", paymentInfo);
            }
            // todo: redirect to an error page
            return View("~/Views/PaymentInfo/Detail.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFastpass(PaymentInfo model)
        {

            // check if customer already has payment info on file
            var checkExists = _context.PaymentInfo
                .Where(p => p.CustomerId == model.CustomerId).FirstOrDefault();
            if (checkExists == null)
            {
                // create new PaymentInfo for that Customer
                PaymentInfo paymentInfo = new PaymentInfo(model.CustomerId, model.PaymentMethod, model.CardholderName, model.CardNumber, model.ExpiryDate);
                _context.PaymentInfo.Add(paymentInfo);
                _context.SaveChanges();
            }

            // todo: 'send off' credit card data here?
            _ticket = _context.Set<Ticket>().Find(model.TicketId);
            _flight = _context.Flights
                .Where(u => u.FlightId == _ticket.FlightId)
                .FirstOrDefault();

            var validFrom = _flight.DepartureTime;
            var validUntil = _flight.ArrivalTime;

            Fastpass fastpass = new Fastpass(_ticket.TicketId, validFrom, validUntil);
            _context.Fastpasses.Add(fastpass);
            _context.SaveChanges();

            return View("~/Views/Home/Index.cshtml"); // redirect to Home page
        }
    }
}
