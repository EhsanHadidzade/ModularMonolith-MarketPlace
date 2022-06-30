namespace ShopManagement.Application.Contract.SellerProduct
{
    public class SellerProductViewModel
    {
        public long Id { get; set; }
        public long SellerPanelId { get; set; }
        public string SellerPanelStoreName { get; set; }
        public int DeliveryDurationForCity { get; set; }
        public int DeliveryDurationForCapital { get; set; }
        public int DeliveryDurationForOther { get; set; }
        public string SellerPanelCompanyName { get; set; }
        public string ProductTitle { get; set; }
        public string PictureUrl { get; set; }
        public long ProductId { get; set; }
        public long Price { get; set; }
        public bool IsConfirmedByAdmin { get; set; }
        public string CreationDate { get; set; }

    }
}
