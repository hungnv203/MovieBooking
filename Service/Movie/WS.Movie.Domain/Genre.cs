﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Domain
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
