using Southwest_Airlines.Data.Models;

namespace Southwest_Airlines.Models
{
    public class SeatModel
    {
        int SeatId { get; set; }
        int SeatNumber { get; set; }
        int FlightId { get; set; }

        public SeatModel(int seatNum, int flightId)
        {
            SeatNumber = seatNum;
            FlightId = flightId;
        }
    }
}
