namespace BiometricManagement_MVC.Models
{
    public class DeviceIn
    {
        public int DeviceInId { get; set; }
        public int UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public User User { get; set; }

    }
}
