namespace RepairWorkShopManagement.Application.Contracts.SystemService
{
    public class SystemServiceViewModel
    {
        public long Id { get; set; }
        public string EngTitle { get; set; }
        public string FarsiTitle { get; set; }
        public long BaseFeePrice { get; set; }
        public int SystemSharePercent { get; set; }

        //FK
        public long ProductBrandId { get; set; }
        public long ProductModelId { get; set; }
        public long ProductTypeId { get; set; }
        public long ProductUsageTypeId { get; set; }
    }
}
