using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface IShowTimeService
    {
        Task<IEnumerable<ShowTimeDto>> GetAllShowTimesAsync();
        Task<ShowTimeDto> GetShowTimeByIdAsync(int id);
        Task<ShowTimeDto> CreateShowTimeAsync(CreateShowTimeDto createShowTimeDto);
        Task<ShowTimeDto> UpdateShowTimeAsync(int id, UpdateShowTimeDto updateShowTimeDto);
        Task<bool> DeleteShowTimeAsync(int id);
    }
}
