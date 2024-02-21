using System;
using System.Collections.Generic;

namespace Southwest_Airlines.Data.Models;

public partial class Seat
{
    public string? SeatNumber { get; set; }

    public bool? IsAvailable { get; set; }

    public decimal? Price { get; set; }

    public int SeatId { get; set; }

    public int FlightId { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
