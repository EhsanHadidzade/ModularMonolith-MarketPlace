namespace RepairWorkShopManagement.Application.Contracts.UserImapairmentReport
{
    public class UserImpairmentReportViewModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public long UserDeviceId { get; set; }

        public string UserFullName { get; set; }
        public string UserDeviceTitle { get; set; }
        public bool IsDone { get; set; }
        public bool IsHandlingByRepairMan { get; set; }

        public string CreationDate { get; set; }
        public long RepairManPanelId { get; set; }
        public string TrackingNo { get; set; }


        //FK(SystemService) FarsiTitles
        //public string BrandFarsiTitle { get; set; }
        //public string ModelFarsiTitle { get; set; }
        //public string TypeFarsiTitle { get; set; }
        //public string UsageTypeFarsiTitle { get; set; }
        //public string SystemServiceFarsiTitle { get; set; }


    }
}
