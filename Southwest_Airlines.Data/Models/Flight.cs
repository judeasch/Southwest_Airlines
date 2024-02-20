using System;
using System.Collections.Generic;

namespace Southwest_Airlines.Data.Models;

public partial class Flight
{
    public int FlightId { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public int? NumberOfSeats { get; set; }

    public bool? IsAvailable { get; set; }

    public decimal? Price { get; set; }

    public int NumberOfFirstClassSeats { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
