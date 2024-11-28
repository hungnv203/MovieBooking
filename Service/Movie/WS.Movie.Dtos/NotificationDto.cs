using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Dtos
{
    public class CreateNotificationDto
    {
        public string Title { get; set; }  // Tiêu đề thông báo
        public string Message { get; set; } // Nội dung thông báo
        public string Type { get; set; } // Loại thông báo
    }
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }
    public class UserNotificationDto
    {
        public int Id { get; set; }  // Thêm Id vào DTO nếu cần
        public int UserId { get; set; } // Thêm UserId vào DTO
        public int NotificationId { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationMessage { get; set; }
        public bool IsRead { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
