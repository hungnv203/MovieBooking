using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Dtos
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public string MovieTitle { get; set; }
        public string CinemaName { get; set; }
        public string RoomName { get; set; }
        public DateTime ShowTime { get; set; }
        public List<SeatDto> Seats { get; set; }
        public decimal TotalPrice { get; set; }
        public string DiscountCode { get; set; }
        public DateTime BookingTime { get; set; }
    }
    public class CreateTicketDto
    {
        public int ShowTimeId { get; set; }
        public List<int> SeatIds { get; set; }
        public int UserId { get; set; }
        public string DiscountCode { get; set; } // Thêm thuộc tính này để nhận mã giảm giá }
    }
}