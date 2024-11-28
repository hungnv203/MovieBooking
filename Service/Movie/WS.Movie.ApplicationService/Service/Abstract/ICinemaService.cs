using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface ICinemaService
    {
        Task<List<CinemaDto>> GetAllCinemasAsync();
        Task<CinemaDto> GetCinemaByIdAsync(int id);
        Task<CinemaDto> CreateCinemaAsync(CreateCinemaDto createCinemaDto);
        Task<CinemaDto> UpdateCinemaAsync(int id, UpdateCinema updateCinemaDto);
        Task<bool> DeleteCinemaAsync(int id);
    }
}
