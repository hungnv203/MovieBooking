using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Domain
{
    public class UserNotification
    {
        public int Id { get; set; } // Thêm Id nếu chưa có

        public int UserId { get; set; }  // Thêm UserId nếu chưa có
        public int NotificationId { get; set; }
        public bool IsRead { get; set; }
        public DateTime DateReceived { get; set; }

        public Notification Notification { get; set; }
        public User User { get; set; }
    }
}
