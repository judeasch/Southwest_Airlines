using Southwest_Airlines.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Southwest_Airlines.Data.Models
{
    public class PaymentInfo
    {
        public int PaymentInfoId { get; set; }
        public int CustomerId { get; set; }
        public string CardholderName { get; set; }
        public string? PaymentMethod { get; set; }
        public string? CardNumber { get; set; }
        public DateOnly ExpiryDate { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int TicketId { get; set; }

        public virtual Customer Customer { get; set; }

        // Constructors
        public PaymentInfo() { }

        public PaymentInfo(int customerId, int ticketId) // constructor for UpdateFastpass
        {
            CustomerId = customerId;
            TicketId = ticketId;
        }

        public PaymentInfo(int customerId, string paymentMethod, string cardholderName, string cardNumber, DateOnly expiryDate)
        {
            CustomerId = customerId;
            PaymentMethod = paymentMethod;
            CardholderName = cardholderName;
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
        }
    }
}
