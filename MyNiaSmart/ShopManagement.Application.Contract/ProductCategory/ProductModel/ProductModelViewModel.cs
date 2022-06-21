namespace ShopManagement.Application.Contract.ProductCategory.ProductModel
{
    public class ProductModelViewModel
    {
        public long Id { get; set; }
        public long ProductBrandId { get; set; }
        public string ProductBrandTitle { get; set; }
        public string EngTitle { get; set; }
        public string FarsiTitle { get; set; }
    }
}
