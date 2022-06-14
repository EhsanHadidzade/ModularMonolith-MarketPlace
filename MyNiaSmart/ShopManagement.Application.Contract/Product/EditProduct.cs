namespace ShopManagement.Application.Contract.Product
{
    public class EditProduct : CreateProduct
    {
        public long Id { get; set; }

        //selectedCategories
        public string ProductBrandTitle { get; set; }
        public string ProductModelTitle { get; set; }
        public string ProductStatusTitle { get; set; }
        public string ProductTypeTitle { get; set; }
        public string ProductUsageTypeTitle { get; set; }
    }
}
