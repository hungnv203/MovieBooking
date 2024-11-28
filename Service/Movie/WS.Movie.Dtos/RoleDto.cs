using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Dtos
{
    public class CreateRoleDto
    {
        public string RoleName { get; set; }
    }
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
    public class UpdateRoleDto
    {
        public string RoleName { get; set; }
    }
}
