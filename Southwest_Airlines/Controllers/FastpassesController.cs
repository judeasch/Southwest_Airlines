using Microsoft.AspNetCore.Identity;
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
            try
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
                
                ModelState.AddModelError("Error", "There was an error processing your ticket information.");
                return Redirect(Request.Headers.Referer.ToString());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "There was an error processing your ticket information.");
                return Redirect(Request.Headers.Referer.ToString());
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFastpass(PaymentInfo model)
        {
            try
            {
                // check to make sure card number is valid
                var cardCheck = CreditCardCheck(model.CardNumber);
                if (!cardCheck)
                {
                    ModelState.AddModelError("Error", "Invalid credit card number.");

                    PaymentInfo paymentInfo = new PaymentInfo(model.CustomerId, model.TicketId);
                    return View("~/Views/PaymentInfo/Detail.cshtml", paymentInfo); // give the user the page again w/ error
                }

                // clear errors if any
                ModelState.ClearValidationState(nameof(model));

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
                _context.Fastpasses.Add(fastpass); // add fastpass to database
                _context.SaveChanges();

                _flight.NumberOfFastpasses = _flight.NumberOfFastpasses - 1; // update the selected flight's available Fastpasses
                _context.SaveChanges();

                return View("~/Views/Shared/_Success.cshtml"); // redirect to Success page
            }
            catch
            {
                ModelState.AddModelError("Error", "There was an error processing your payment information.");

                PaymentInfo paymentInfo = new PaymentInfo(model.CustomerId, model.TicketId);
                return View("~/Views/PaymentInfo/Detail.cshtml", paymentInfo); // give the user the page again w/ error
            }
        }

        public static bool CreditCardCheck(string creditCardNumber)
        {
            // check whether input string is null or empty
            if (string.IsNullOrEmpty(creditCardNumber))
            {
                return false;
            }

            // use luhn algorithm to validate card
            int sumOfDigits = creditCardNumber.Where((e) => e >= '0' && e <= '9')
                            .Reverse()
                            .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                            .Sum((e) => e / 10 + e % 10);
            
            // if input wasn't valid then return false
            if (sumOfDigits == 0) 
            { 
                return false;
            }

            // If the final sum is divisible by 10, then the credit card number is valid         
            return sumOfDigits % 10 == 0;
        }
    }
}
