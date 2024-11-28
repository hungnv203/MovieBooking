using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Domain
{
    public class Seat
    {
        public int Id { get; set; }
        public int CinemaRoomId { get; set; }
        public string SeatCode { get; set; }
        public string SeatType { get; set; } = "Regular";
        public decimal Price { get; set; }

        public CinemaRoom CinemaRoom { get; set; }
    } 
}
