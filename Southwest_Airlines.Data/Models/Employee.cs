using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southwest_Airlines.Data.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string? UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public List<Flight> Flights { get; set; } = [];
        public List<EmployeeFlight> EmployeeFlights { get; set; } = [];
    }
}
