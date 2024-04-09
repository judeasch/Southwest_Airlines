using Southwest_Airlines.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Southwest_Airlines.Data.Models
{
    internal class FastPass
    {
    }
}
public class FastPass
{
    public int FastPassId { get; set; }
    public int TicketId { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidUntil { get; set; }
    public virtual Ticket Ticket { get; set; }

    public FastPass(int ticketId, DateTime validFrom, DateTime validUntil)
    {
        TicketId = ticketId;
        ValidFrom = validFrom;
        ValidUntil = validUntil;
     
    }
}