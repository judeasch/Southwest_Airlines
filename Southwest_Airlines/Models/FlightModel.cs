using Southwest_Airlines.Data.Models;

namespace Southwest_Airlines.Models
{
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
            NumberOfRows = flight.NumberOfSeats / 6;
            
            
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

        public Dictionary<string, string> ConvertSeatNumbers(Dictionary<string, string> seats) 
        {
            Dictionary<string, string> convertedSeats = new Dictionary<string, string>();
            // var totalrows = NumberOfSeats / 6;   // 6 seats to a row
            string[] letters = ["a", "b", "c", "d", "e", "f"];
            var count = 0;

            for (var i = 0; i < NumberOfRows; i++)
            {
                for (var e = 0; e < 6; e++)
                {
                    var seatNum = seats.ElementAt(count).Key;
                    seatNum += letters[e];
                    convertedSeats.Add(seatNum, seats.ElementAt(count).Value);
                    count++;
                }                    
            }
            
            return convertedSeats;
        }
    }
}
