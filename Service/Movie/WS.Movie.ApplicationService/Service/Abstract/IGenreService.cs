using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetAllAsync();
        Task<GenreDto> GetByIdAsync(int id);
        Task<GenreDto> GetByNameAsync(string name);
        Task<GenreDto> CreateAsync(CreateGenreDto dto);
        Task<GenreDto> UpdateAsync(int id, UpdateGenreDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
