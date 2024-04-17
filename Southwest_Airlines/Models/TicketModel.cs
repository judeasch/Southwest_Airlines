using Southwest_Airlines.Data.Models;

namespace Southwest_Airlines.Models
{
    public class TicketListModel
    {
        public List<Ticket> Tickets { get; set; }
        public List<Flight> Flights { get; set; }
        public List<Seat> Seats { get; set; }
        public List<Fastpass> Fastpasses { get; set; }

        public TicketListModel(List<Ticket> tickets, List<Flight> flights, List<Seat> seats, List<Fastpass> fastpasses)
        {
            Tickets = tickets;
            Flights = flights;
            Seats = seats;
            Fastpasses = fastpasses;
        }
    }
}
