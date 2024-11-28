﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Dtos
{
    public class CreateShowTimeDto
    {
        public string MovieTitle { get; set; } // Tên phim
        public string CinemaName { get; set; } // Tên rạp
        public string CinemaRoomName { get; set; } // Tên phòng chiếu
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    public class ShowTimeDto
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; } // Tên phim
        public string CinemaName { get; set; } // Tên rạp
        public string CinemaRoomName { get; set; } // Tên phòng chiếu
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    public class UpdateShowTimeDto
    {
        public string MovieTitle { get; set; } // Tên phim
        public string CinemaName { get; set; } // Tên rạp
        public string CinemaRoomName { get; set; } // Tên phòng chiếu
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
