using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.ApplicationService.Service.Abstract;
using WS.Movie.Domain;
using WS.Movie.Dtos;
using WS.Movie.Infrastructure;

namespace WS.Movie.ApplicationService.Service.Implement
{
    public class TicketService : ITicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDiscountService _discountService;

        public TicketService(ApplicationDbContext context,IDiscountService discountService)
        {
            _context = context;
            _discountService = discountService;
        }

        public async Task<TicketDto> CreateTicketAsync(CreateTicketDto createTicketDto)
        {   
            var showTime = await _context.ShowTimes 
                .Include(st => st.Movie)
                .Include(st => st.CinemaRoom.Cinema) 
                .FirstOrDefaultAsync(st => st.Id == createTicketDto.ShowTimeId);
            if (showTime == null) {
                throw new Exception("ShowTime not found");
            }
               
            // Kiểm tra danh sách ghế
            if (createTicketDto.SeatIds == null || !createTicketDto.SeatIds.Any())
            {
                throw new Exception("No seats selected");
            }
                
            // Kiểm tra tính khả dụng của ghế
            var seats = await _context.Seats
                .Where(s => createTicketDto.SeatIds.Contains(s.Id) && !_context.TicketSeats
                .Any(ts => ts.SeatId == s.Id && ts.Status == "Booked")) 
                .ToListAsync(); 
            if (seats.Count != createTicketDto.SeatIds.Count)
                throw new Exception("One or more seats are already booked");
            var totalPrice = seats.Sum(s => s.Price);
            // Áp dụng mã giảm giá (nếu có)
            if (!string.IsNullOrEmpty(createTicketDto.DiscountCode))
            { 
                var discountApplied = await _discountService.ApplyDiscountAsync(createTicketDto.UserId, createTicketDto.DiscountCode);
                if (discountApplied) 
                { 
                    var discount = await _context.Discounts.SingleOrDefaultAsync(d => d.Code == createTicketDto.DiscountCode);
                    if (discount != null) 
                    { 
                     
                        totalPrice -= totalPrice * ((decimal)discount.Percentage / 100);
                    } 
                } 
            }
            var ticket = new Ticket { 
                UserId = createTicketDto.UserId, 
                ShowTimeId = createTicketDto.ShowTimeId,
                TotalPrice = totalPrice, 
                BookingTime = DateTime.UtcNow };
            _context.Tickets.Add(ticket); 
            await _context.SaveChangesAsync();
            foreach (var seat in seats) {
                var ticketSeat = new TicketSeat { 
                    TicketId = ticket.Id, SeatId = seat.Id,
                    Status = "Booked" 
                }; 
                _context.TicketSeats.Add(ticketSeat); 
            } 
            await _context.SaveChangesAsync(); 
            return new TicketDto { 
                TicketId = ticket.Id, 
                MovieTitle = showTime.Movie.Title,
                CinemaName = showTime.CinemaRoom.Cinema.Name, 
                RoomName = showTime.CinemaRoom.Name,
                ShowTime = showTime.StartTime, 
                Seats = seats.Select(s => new SeatDto(s)).ToList(),
                TotalPrice = ticket.TotalPrice, 
                BookingTime = ticket.BookingTime
            }; 
        }

            public async Task<List<TicketDto>> GetAllTicketsAsync()
        {
            return await _context.Tickets.Include(t => t.ShowTime)
                                         .Include(t => t.TicketSeats)
                                         .ThenInclude(ts => ts.Seat)
                                         .Select(t => new TicketDto
                                         {
                                             TicketId = t.Id,
                                             MovieTitle = t.ShowTime.Movie.Title,
                                             CinemaName = t.ShowTime.CinemaRoom.Cinema.Name,
                                             RoomName = t.ShowTime.CinemaRoom.Name,
                                             ShowTime = t.ShowTime.StartTime,
                                             Seats = t.TicketSeats.Select(ts => new SeatDto
                                             {
                                                 Id = ts.Seat.Id,
                                                 SeatCode = ts.Seat.SeatCode,
                                                 SeatType = ts.Seat.SeatType,
                                                 Price = ts.Seat.Price
                                             }).ToList(),
                                             TotalPrice = t.TotalPrice,
                                             BookingTime = t.BookingTime
                                         }).ToListAsync();
        }

        public async Task<TicketDto> GetTicketByIdAsync(int ticketId)
        {
            var ticket = await _context.Tickets
                .Include(t => t.ShowTime)
                .Include(t => t.TicketSeats)
                .ThenInclude(ts => ts.Seat)
                .FirstOrDefaultAsync(t => t.Id == ticketId);

            if (ticket == null) return null;

            return new TicketDto
            {
                TicketId = ticket.Id,
                MovieTitle = ticket.ShowTime.Movie.Title,
                CinemaName = ticket.ShowTime.CinemaRoom.Cinema.Name,
                RoomName = ticket.ShowTime.CinemaRoom.Name,
                ShowTime = ticket.ShowTime.StartTime,
                Seats = ticket.TicketSeats.Select(ts => new SeatDto
                {
                    Id = ts.Seat.Id,
                    SeatCode = ts.Seat.SeatCode,
                    SeatType = ts.Seat.SeatType,
                    Price = ts.Seat.Price
                }).ToList(),
                TotalPrice = ticket.TotalPrice,
                BookingTime = ticket.BookingTime
            };
        }
    }
}
