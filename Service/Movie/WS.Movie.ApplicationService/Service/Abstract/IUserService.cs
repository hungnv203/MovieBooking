using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task<UserDto> GetByEmailAsync(string email);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        public UserDto FindUserById();
        Task<UserDto> UpdateAsync(int id, UpdateUserDto dto);
        Task<bool> UpdatePasswordAsync(int userId, UpdatePasswordDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
