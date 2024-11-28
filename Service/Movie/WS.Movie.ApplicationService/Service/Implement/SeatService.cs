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
    public class SeatService : ISeatService
    {
        private readonly ApplicationDbContext _context;

        public SeatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SeatDto>> GenerateSeatsAsync(int cinemaRoomId)
        {
            var room = await _context.CinemaRooms.FindAsync(cinemaRoomId);
            if (room == null) throw new Exception("Cinema Room not found");

            var seats = new List<Seat>();
            for (int i = 0; i < room.SeatRows; i++)
            {
                for (int j = 1; j <= room.SeatColumns; j++)
                {
                    var seatCode = $"{(char)('A' + i)}{j}";
                    seats.Add(new Seat
                    {
                        CinemaRoomId = cinemaRoomId,
                        SeatCode = seatCode,
                        SeatType = "Regular",
                        Price = 100m // giá mặc định
                    });
                }
            }

            await _context.Seats.AddRangeAsync(seats);
            await _context.SaveChangesAsync();

            return seats.Select(s => new SeatDto(s)).ToList();
        }

        public async Task<List<SeatDto>> GetSeatsByRoomAsync(int cinemaRoomId)
        {
            var seats = await _context.Seats
                .Where(s => s.CinemaRoomId == cinemaRoomId)
                .ToListAsync();
            return seats.Select(s => new SeatDto(s)).ToList();
        }
    }
}
