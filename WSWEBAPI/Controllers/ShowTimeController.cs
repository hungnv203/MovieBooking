﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WS.Movie.ApplicationService.Service.Abstract;
using WS.Movie.Dtos;

namespace WSWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] // Restrict access to Admin and Manager roles
    public class ShowTimeController : ControllerBase
    {
        private readonly IShowTimeService _showTimeService;

        public ShowTimeController(IShowTimeService showTimeService)
        {
            _showTimeService = showTimeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var showTimes = await _showTimeService.GetAllShowTimesAsync();
                return Ok(showTimes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var showTime = await _showTimeService.GetShowTimeByIdAsync(id);
                return showTime == null ? NotFound() : Ok(showTime);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShowTimeDto createShowTimeDto)
        {
            try
            {
                var showTime = await _showTimeService.CreateShowTimeAsync(createShowTimeDto);
                if (showTime == null) return BadRequest("Movie, Cinema, or CinemaRoom not found");

                return CreatedAtAction(nameof(GetById), new { id = showTime.Id }, showTime);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateShowTimeDto updateShowTimeDto)
        {
            try
            {
                var showTime = await _showTimeService.UpdateShowTimeAsync(id, updateShowTimeDto);
                return showTime == null ? NotFound() : Ok(showTime);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _showTimeService.DeleteShowTimeAsync(id);
                return deleted ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
