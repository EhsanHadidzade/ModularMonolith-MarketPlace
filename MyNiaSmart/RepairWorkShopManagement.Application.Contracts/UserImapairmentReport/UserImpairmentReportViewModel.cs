namespace RepairWorkShopManagement.Application.Contracts.UserImapairmentReport
{
    public class UserImpairmentReportViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long UserDeviceId { get; set; }
        public long SystemServiceId { get; set; }

        public string UserDeviceTitle { get; set; }
        public string SystemServiceTitle { get; set; }


    }
}
