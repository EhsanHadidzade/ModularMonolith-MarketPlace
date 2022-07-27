namespace AccountManagement.Application.Contract.UserDevice
{
    public class UserDeviceViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public string DeviceTitle { get; set; }
        public string DevicePictureURL { get; set; }
        public string Address { get; set; }
        public string CreationDate { get; set; }
    }
}
