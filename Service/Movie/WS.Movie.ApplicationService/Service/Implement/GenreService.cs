﻿using Microsoft.EntityFrameworkCore;
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
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _context;

        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GenreDto>> GetAllAsync()
        {
            return await _context.Genres
                .Select(g => new GenreDto { Id = g.Id, Name = g.Name })
                .ToListAsync();
        }

        public async Task<GenreDto> GetByIdAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            return genre == null ? null : new GenreDto { Id = genre.Id, Name = genre.Name };
        }

        public async Task<GenreDto> GetByNameAsync(string name)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Name == name);
            return genre == null ? null : new GenreDto { Id = genre.Id, Name = genre.Name };
        }

        public async Task<GenreDto> CreateAsync(CreateGenreDto dto)
        {
            var genre = new Genre { Name = dto.Name };
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return new GenreDto { Id = genre.Id, Name = genre.Name };
        }

        public async Task<GenreDto> UpdateAsync(int id, UpdateGenreDto dto)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null) return null;

            genre.Name = dto.Name;
            await _context.SaveChangesAsync();
            return new GenreDto { Id = genre.Id, Name = genre.Name };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null) return false;

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
