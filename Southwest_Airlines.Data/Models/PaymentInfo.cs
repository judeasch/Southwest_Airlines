using Southwest_Airlines.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public virtual Customer Customer { get; set; }

        // Constructors
        public PaymentInfo() { }

        public PaymentInfo(int customerId)
        {
            CustomerId = customerId;
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
