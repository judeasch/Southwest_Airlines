using Southwest_Airlines.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southwest_Airlines.Data.Models
{
    internal class PaymentInfo
    {
    }
}
public class PaymentInfo
{
    public int PaymentInfoId { get; set; }
    public int CustomerId { get; set; }
    public string CardholderName { get; set; }
    public string? PaymentMethod { get; set; } 
    public string? CardNumber { get; set; } 
    public string? ExpiryDate { get; set; } 

    public virtual Customer Customer { get; set; }

    // Constructor
    public PaymentInfo(int customerId, string paymentMethod, string cardholderName, string cardNumber, string expiryDate)
    {
        CustomerId = customerId;
        PaymentMethod = paymentMethod;
        CardholderName = cardholderName;
        CardNumber = cardNumber;
        ExpiryDate = expiryDate;
       
       
    }
}