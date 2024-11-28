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
    public class CinemaService : ICinemaService
    {
        private readonly ApplicationDbContext _context;

        public CinemaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CinemaDto>> GetAllCinemasAsync()
        {
            return await _context.Cinemas
                .Select(c => new CinemaDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Location = c.Address
                })
                .ToListAsync();
        }

        public async Task<CinemaDto> GetCinemaByIdAsync(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null) return null;

            return new CinemaDto
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Address
            };
        }

        public async Task<CinemaDto> CreateCinemaAsync(CreateCinemaDto createCinemaDto)
        {
            var cinema = new Cinema
            {
                Name = createCinemaDto.Name,
                Address = createCinemaDto.Location
            };

            _context.Cinemas.Add(cinema);
            await _context.SaveChangesAsync();

            return new CinemaDto
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Address
            };
        }

        public async Task<CinemaDto> UpdateCinemaAsync(int id, UpdateCinema updateCinemaDto)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null) return null;

            cinema.Name = updateCinemaDto.Name;
            cinema.Address = updateCinemaDto.Location;

            await _context.SaveChangesAsync();

            return new CinemaDto
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Address
            };
        }

        public async Task<bool> DeleteCinemaAsync(int id)
        {
            var cinema = await _context.Cinemas.FindAsync(id);
            if (cinema == null) return false;

            _context.Cinemas.Remove(cinema);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
