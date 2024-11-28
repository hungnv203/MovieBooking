using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Dtos
{
    public class UpdateActorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class CreateActorDto
    {
        public string Name { get; set; }
    }
    public class ActorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
