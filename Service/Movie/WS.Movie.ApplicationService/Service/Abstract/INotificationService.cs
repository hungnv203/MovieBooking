using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Movie.Domain;
using WS.Movie.Dtos;

namespace WS.Movie.ApplicationService.Service.Abstract
{
    public interface INotificationService
    {
        Task AddNotificationAsync(Notification notification);
        Task SendNotificationAsync(int userId, Notification notification); // Gửi thông báo
        Task<List<UserNotificationDto>> GetUserNotificationsAsync(int userId);   // Lấy thông báo của người dùng
        Task MarkNotificationAsReadAsync(int userId, int notificationId); // Đánh dấu thông báo đã đọc
    }
}
