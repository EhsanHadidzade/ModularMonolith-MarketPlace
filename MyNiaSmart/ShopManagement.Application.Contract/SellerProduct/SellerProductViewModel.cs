namespace ShopManagement.Application.Contract.SellerProduct
{
    public class SellerProductViewModel
    {
        public long Id { get; set; }
        public long SellerPanelId { get; set; }
        public string SellerPanelStoreName { get; set; }
        public string ProductTitle { get; set; }
        public string PictureUrl { get; set; }
        public long ProductId { get; set; }
        public long Price { get; set; }
        public bool IsConfirmedByAdmin { get; set; }
        public string CreationDate { get; set; }

    }
}
