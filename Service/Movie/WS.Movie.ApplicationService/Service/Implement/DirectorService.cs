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
    public class DirectorService : IDirectorService
    {
        private readonly ApplicationDbContext _context;

        public DirectorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DirectorDto>> GetAllAsync()
        {
            return await _context.Directors
                .Select(d => new DirectorDto { Id = d.Id, Name = d.Name })
                .ToListAsync();
        }

        public async Task<DirectorDto> GetByIdAsync(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            return director == null ? null : new DirectorDto { Id = director.Id, Name = director.Name };
        }

        public async Task<DirectorDto> GetByNameAsync(string name)
        {
            var director = await _context.Directors.FirstOrDefaultAsync(d => d.Name == name);
            return director == null ? null : new DirectorDto { Id = director.Id, Name = director.Name };
        }

        public async Task<DirectorDto> CreateAsync(CreateDirectorDto dto)
        {
            var director = new Director { Name = dto.Name };
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();
            return new DirectorDto { Id = director.Id, Name = director.Name };
        }

        public async Task<DirectorDto> UpdateAsync(int id, UpdateDirectorDto dto)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null) return null;

            director.Name = dto.Name;
            await _context.SaveChangesAsync();
            return new DirectorDto { Id = director.Id, Name = director.Name };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null) return false;

            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
