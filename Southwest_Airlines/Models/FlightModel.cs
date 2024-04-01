using Southwest_Airlines.Data.Models;

namespace Southwest_Airlines.Models
{
    public class FlightListModel
    {
        public List<Flight> Flights { get; set; }
        public FlightListModel(List<Flight> flights) 
        {
            Flights = flights;
        }
    }

    public class FlightModel
    {
        public int? FlightId { get; set; }
        public int? NumberOfSeats { get; set; }
        public int? NumberOfRows { get; set; }
        public Dictionary<string, string> Seats { get; set; } = new Dictionary<string, string>();

        public FlightModel(Flight flight, List<Seat> seats) 
        {
            Dictionary<string, string> initialSeats = new Dictionary<string, string>();
            List<string?> seatNumList = seats.Select(s => s.SeatNumber).ToList();
            FlightId = flight.FlightId;
            NumberOfSeats = flight.NumberOfSeats;
            NumberOfRows = flight.NumberOfSeats / 6;  // todo: add functionality for when numberofseats isn't multiple of 6
            
            
            for (int i = 1; i <= NumberOfSeats; i++)
            {                
                if (seatNumList.Contains(i.ToString()))
                {
                    initialSeats.Add(seatNumList.First(s => s == i.ToString()), "unavailable");
                }

                else
                {
                    initialSeats.Add(i.ToString(), "available");
                }               
                    
            }
                       
            Seats = ConvertSeatNumbers(initialSeats);
        }

        // todo: maybe put this in a list of helper methods?
        public Dictionary<string, string> ConvertSeatNumbers(Dictionary<string, string> seats) 
        {
            Dictionary<string, string> convertedSeats = new Dictionary<string, string>();
            string[] letters = ["A", "B", "C", "D", "E", "F"];  // airplane seats have a number followed by a letter, ex: 1A, 3C, etc
            var count = 0; // keep track of the current index in seats

            for (var i = 0; i < NumberOfRows; i++)
            {
                for (var e = 0; e < 6; e++)
                {
                    var seatNum = seats.ElementAt(count).Key;
                    seatNum += letters[e];
                    convertedSeats.Add(seatNum, seats.ElementAt(count).Value); // format seat number correctly and add to dict
                    count++;
                }                    
            }
            
            return convertedSeats;
        }
    }
}
