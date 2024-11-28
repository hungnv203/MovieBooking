using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShowTimeId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime BookingTime { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ShowTime ShowTime { get; set; }
        public ICollection<TicketSeat> TicketSeats { get; set; }
        public ICollection<TicketDiscount> TicketDiscounts { get; set; }
    }
}
