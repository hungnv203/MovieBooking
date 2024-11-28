using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface IActorService
    {
        Task<List<ActorDto>> GetAllAsync();
        Task<ActorDto> GetByIdAsync(int id);
        Task<ActorDto> GetByNameAsync(string name);
        Task<ActorDto> CreateAsync(CreateActorDto dto);
        Task<ActorDto> UpdateAsync(int id, UpdateActorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
