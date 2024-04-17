using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southwest_Airlines.Data.Models
{
    public class EmployeeFlight
    {
        public int EmployeeId { get; set; }
        public int FlightId { get; set;}
        public Employee Employee { get; set; } = null;
        public Flight Flight { get; set; } = null;

    }
}
