using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface ICinemaRoomService
    {
        Task<IEnumerable<CinameRoomDto>> GetAllCinemaRoomsAsync();
        Task<CinameRoomDto> GetCinemaRoomByIdAsync(int id);
        Task<CinameRoomDto> CreateCinemaRoomAsync(CreateCinemaRoomDto createCinemaRoomDto);
        Task<CinameRoomDto> UpdateCinemaRoomAsync(int id, UpdateCinemaRoomDto updateCinemaRoomDto);
        Task<bool> DeleteCinemaRoomAsync(int id);
    }
}
