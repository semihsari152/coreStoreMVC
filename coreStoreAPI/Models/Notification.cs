using System.ComponentModel.DataAnnotations;

namespace coreStoreAPI.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public string? NotificationType { get; set; }
        public string? NotificationDetails { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool NotificationStatus { get; set; }
    }
}