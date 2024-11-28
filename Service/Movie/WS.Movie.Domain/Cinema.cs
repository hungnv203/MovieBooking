using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Domain
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        // Navigation property
        public ICollection<CinemaRoom> CinemaRooms { get; set; }
    }
}
