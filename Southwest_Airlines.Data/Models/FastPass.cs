using Southwest_Airlines.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southwest_Airlines.Data.Models
{
    public class Fastpass
    {
        public int FastpassId { get; set; }
        public int TicketId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public virtual Ticket Ticket { get; set; }

        public Fastpass(int ticketId, DateTime validFrom, DateTime validUntil)
        {
            TicketId = ticketId;
            ValidFrom = validFrom;
            ValidUntil = validUntil;
        }
    }
}
