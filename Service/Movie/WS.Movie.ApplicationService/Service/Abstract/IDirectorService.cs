using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface IDirectorService
    {
        Task<List<DirectorDto>> GetAllAsync();
        Task<DirectorDto> GetByIdAsync(int id);
        Task<DirectorDto> CreateAsync(CreateDirectorDto dto);
        Task<DirectorDto> UpdateAsync(int id, UpdateDirectorDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
