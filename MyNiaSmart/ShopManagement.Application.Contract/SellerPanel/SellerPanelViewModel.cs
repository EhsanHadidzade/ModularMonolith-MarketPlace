namespace ShopManagement.Application.Contract.SellerPanel
{
    public class SellerPanelViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string SellerFullName { get; set; }
        public string StoreName { get; set; }
        public string CompanyName { get; set; }
        public string StoreMobileNumber { get; set; }
        public string Capital { get; set; }
        public bool Islegal { get; set; }
        public bool IsConfirmByAdmin { get; set; }
        public bool IsSpecial { get; set; }
        public string City { get; set; }
    }
}
