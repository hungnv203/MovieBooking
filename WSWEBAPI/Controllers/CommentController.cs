﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WS.Movie.ApplicationService.Service.Abstract;
using WS.Movie.Dtos;

namespace WSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/Comments/movie/{movieId}
        [HttpGet("movie/{movieId}")]
        public async Task<IActionResult> GetCommentsByMovieId(int movieId)
        {
            try
            {
                var comments = await _commentService.GetCommentsByMovieIdAsync(movieId);
                return Ok(comments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Comments/{commentId}
        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            try
            {
                var comment = await _commentService.GetCommentByIdAsync(commentId);
                if (comment == null)
                {
                    return NotFound("Comment not found.");
                }

                return Ok(comment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Comments
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto commentCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var comment = await _commentService.CreateCommentAsync(commentCreateDTO);
                return CreatedAtAction(nameof(GetCommentById), new { commentId = comment.Id }, comment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Comments/{commentId}
        [HttpPut("{commentId}")]
        public async Task<IActionResult> UpdateComment(int commentId, [FromBody] UpdateCommentDto commentUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedComment = await _commentService.UpdateCommentAsync(commentId, commentUpdateDTO);
                if (updatedComment == null)
                {
                    return NotFound("Comment not found.");
                }

                return Ok(updatedComment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/Comments/{commentId}
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            try
            {
                var result = await _commentService.DeleteCommentAsync(commentId);
                if (!result)
                {
                    return NotFound("Comment not found.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
