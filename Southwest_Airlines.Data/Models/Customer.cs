using System;
using System.Collections.Generic;

namespace Southwest_Airlines.Data.Models;

public partial class Customer
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Country { get; set; }

    public string? State { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public string? Address { get; set; }

    public int CustomerId { get; set; }

    public string LoginId { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
