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
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CommentDTO>> GetCommentsByMovieIdAsync(int movieId)
        {
            return await _context.Comments
                .Where(c => c.MovieId == movieId)
                .Select(c => new CommentDTO
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    MovieId = c.MovieId,
                    Content = c.Content,
                    Rating = c.Rating,
                    CreatedAt = c.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<CommentDTO> GetCommentByIdAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
            {
                return null;
            }

            return new CommentDTO
            {
                Id = comment.Id,
                UserId = comment.UserId,
                MovieId = comment.MovieId,
                Content = comment.Content,
                Rating = comment.Rating,
                CreatedAt = comment.CreatedAt
            };
        }

        public async Task<CommentDTO> CreateCommentAsync(CreateCommentDto commentCreateDTO)
        {
            var comment = new Comment
            {
                UserId = commentCreateDTO.UserId,
                MovieId = commentCreateDTO.MovieId,
                Content = commentCreateDTO.Content,
                Rating = commentCreateDTO.Rating,
                CreatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return new CommentDTO
            {
                Id = comment.Id,
                UserId = comment.UserId,
                MovieId = comment.MovieId,
                Content = comment.Content,
                Rating = comment.Rating,
                CreatedAt = comment.CreatedAt
            };
        }

        public async Task<CommentDTO> UpdateCommentAsync(int commentId, UpdateCommentDto commentUpdateDTO)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
            {
                return null;
            }

            comment.Content = commentUpdateDTO.Content;
            comment.Rating = commentUpdateDTO.Rating;

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            return new CommentDTO
            {
                Id = comment.Id,
                UserId = comment.UserId,
                MovieId = comment.MovieId,
                Content = comment.Content,
                Rating = comment.Rating,
                CreatedAt = comment.CreatedAt
            };
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
            {
                return false;
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
