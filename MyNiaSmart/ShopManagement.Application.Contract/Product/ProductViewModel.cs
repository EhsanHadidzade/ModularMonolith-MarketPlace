namespace ShopManagement.Application.Contract.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string PictureURL { get; set; }
        public string EngTitle { get; set; }
        public string FarsiTitle { get; set; }
        public string PartNumber { get; set; }
        public string Slug { get; set; }
        public string CreationDate { get; set; }

        //FK
        public long ProductBrandId { get; set; }
        public long ProductModelId { get; set; }
        public long ProductTypeId { get; set; }
        public long ProductUsageTypeId { get; set; }

        //FK Titles
        public string BrandEngTitle { get; set; }
        public string ModelEngTitle { get; set; }
        public string TypeEngTitle { get; set; }
        public string UsageTypeEngTitle { get; set; }
    }
}
