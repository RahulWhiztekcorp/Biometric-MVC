namespace BiometricManagement_MVC.Models
{
    public class DeviceOut
    {
        public int DeviceOutId { get; set; }
        public int UserId { get; set; }
        public DateTime LogoutTime { get; set; }
        public User User { get; set; }

    }
}
