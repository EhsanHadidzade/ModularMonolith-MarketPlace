namespace RepairWorkShopManagement.Application.Contracts.SystemService
{
    public class SystemServiceViewModel
    {
        public long Id { get; set; }
        public string EngTitle { get; set; }
        public long BaseFeePrice { get; set; }
        public int SystemSharePercent { get; set; }
    }
}
