namespace RepairWorkShopManagement.Application.Contracts.UserImapairmentReport
{
    public class EditUserImpairmentReport:CreateUserImpairmentReport
    {
        public long Id { get; set; }

        public string UserDeviceLong { get; set; }
        public string UserDeviceLatt { get; set; }
        public string UserDeviceAddress { get; set; }

        public string UserDeviceBrandTitle { get; set; }
        public string UserDeviceModelTitle { get; set; }
        public string UserDeviceTypeTitle { get; set; }
        public string UserDeviceUsageTypeTitle { get; set; }

    }
}
