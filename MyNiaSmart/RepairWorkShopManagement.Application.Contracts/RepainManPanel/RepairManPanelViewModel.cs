namespace RepairWorkShopManagement.Application.Contracts.RepainManPanel
{
    public class RepairManPanelViewModel
    {
        public long Id { get; set; }
        public string CommericalFullName { get; set; } //نام تجاری
        public string Capital { get; set; }
        public string City { get; set; }
        public bool IsConfirmedByAdmin { get; set; }

    }
}
