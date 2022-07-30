namespace RepairWorkShopManagement.Application.Contracts.RepairManService
{
    public class EditRepairManService:CreateRepairManService
    {
        public long Id { get; set; }
        public long SystemServiceId { get; set; }
    }
}
