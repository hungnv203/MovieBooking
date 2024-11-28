using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Dtos
{
    public class CinemaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
    public class CreateCinemaDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
    public class UpdateCinema
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
