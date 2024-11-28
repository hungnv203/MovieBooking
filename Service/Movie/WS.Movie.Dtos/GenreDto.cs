using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Dtos
{
    public class CreateGenreDto
    {
        public string Name { get; set; }
    }
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateGenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
