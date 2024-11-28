using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllAsync();
        Task<RoleDto> CreateAsync(CreateRoleDto dto);
        Task<RoleDto> UpdateAsync(int id, UpdateRoleDto dto);

    }
}
