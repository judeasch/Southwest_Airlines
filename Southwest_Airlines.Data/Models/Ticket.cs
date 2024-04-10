﻿using System;
using System.Collections.Generic;

namespace Southwest_Airlines.Data.Models;

public class Ticket
{
    public Ticket(int? seatId, int? flightId, int? customerId) 
    { 
        SeatId = seatId;
        FlightId = flightId;
        CustomerId = customerId;
    }
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

    public virtual ICollection<Fastpass> Fastpasses { get; set; } = new List<Fastpass>();
}
