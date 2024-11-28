using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface ISeatService
    {
        Task<List<SeatDto>> GenerateSeatsAsync(int cinemaRoomId);
        Task<List<SeatDto>> GetSeatsByRoomAsync(int cinemaRoomId);
    }
}
