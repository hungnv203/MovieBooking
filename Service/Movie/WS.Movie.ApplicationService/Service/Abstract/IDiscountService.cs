using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface IDiscountService { 
        Task<IEnumerable<DiscountDto>> GetAllDiscountsAsync();
        Task<DiscountDto> GetDiscountByIdAsync(int id);
        Task<DiscountDto> CreateDiscountAsync(CreateDiscountDto createDiscountDto);
        Task<DiscountDto> UpdateDiscountAsync(int id, UpdateDiscountDto updateDiscountDto);
        Task<bool> DeleteDiscountAsync(int id); 
        Task<bool> ApplyDiscountAsync(int userId, string code); 
    }
}
