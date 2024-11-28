﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Domain
{
    public class CinemaRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public int SeatRows { get; set; }
        public int SeatColumns { get; set; }

        public List<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();
    }
}
