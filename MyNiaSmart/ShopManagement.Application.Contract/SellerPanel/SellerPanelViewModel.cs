namespace ShopManagement.Application.Contract.SellerPanel
{
    public class SellerPanelViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string SellerFullName { get; set; }
        public string StoreName { get; set; }
        public string StoreMobileNumber { get; set; }
        public string StoreAddress { get; set; }
    }
}
