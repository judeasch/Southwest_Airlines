using System;
using System.Collections.Generic;

namespace Southwest_Airlines.Data.Models;

public partial class Ticket
{
    public int? CustomerId { get; set; }

    public int? FlightId { get; set; }

    public int? SeatId { get; set; }

    public DateTime? BookingDate { get; set; }

    public string? Status { get; set; }

    public decimal? PricePaid { get; set; }

    public int TicketId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Flight? Flight { get; set; }

    public virtual Seat? Seat { get; set; }
}
