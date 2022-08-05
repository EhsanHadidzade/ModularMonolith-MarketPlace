namespace RepairWorkShopManagement.Application.Contracts.RepairManService
{
    public class EditRepairManService:CreateRepairManService
    {
        public long Id { get; set; }
        public long SystemServiceId { get; set; }


        //Categories
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string UsageType { get; set; }


    
    }
}
