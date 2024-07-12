namespace BiometricManagement_MVC.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public ICollection<DeviceIn> DevicesIn { get; set; }
        public ICollection<DeviceOut> DevicesOut { get; set; }

    }
}
