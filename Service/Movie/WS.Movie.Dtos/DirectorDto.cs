using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Dtos
{
    public class CreateDirectorDto
    {
        public string Name { get; set; }
    }
    public class DirectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateDirectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
