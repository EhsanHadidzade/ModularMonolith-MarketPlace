namespace ShopManagement.Application.Contract.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string EngTitle { get; set; }
        public string FarsiTitle { get; set; }
        public string PartNumber { get; set; }
        public string Slug { get; set; }
        public string CreationDate { get; set; }
    }
}
