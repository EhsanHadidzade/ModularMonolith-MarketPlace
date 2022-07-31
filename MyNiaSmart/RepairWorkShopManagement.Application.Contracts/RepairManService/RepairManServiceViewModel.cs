namespace RepairWorkShopManagement.Application.Contracts.RepairManService
{
    public class RepairManServiceViewModel
    {
        public long Id { get; set; }
        public string RepairManFullName { get; set; }
        public long RepairManPanelId { get; set; }
        public long SystemServiceId { get; set; }

        //Categories
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string UsageType { get; set; }
        public string SystemServiceTitle { get; set; }

        public bool IsConfirmedByAdmin { get; set; }
        public bool IsEditionConfirmedByAdmin { get; set; }
        public string CreationDate { get; set; }


    }
}
