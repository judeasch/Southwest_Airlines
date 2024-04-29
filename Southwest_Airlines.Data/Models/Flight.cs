using System;
using System.Collections.Generic;

namespace Southwest_Airlines.Data.Models;

public partial class Flight
{
    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }

    public int NumberOfSeats { get; set; }

    public int TotalNumberOfSeats { get; set; }

    public int NumberOfFastpasses { get; set; }

    public int FlightId { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public List<Employee> Employees { get; set; } = [];
    public List<EmployeeFlight> EmployeeFlights { get; set; } = [];
}
