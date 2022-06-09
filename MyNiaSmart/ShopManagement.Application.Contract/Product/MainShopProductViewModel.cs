using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Product
{
    public class MainShopProductViewModel
    {
        public long Id { get; set; }
        public string FarsiTitle { get; set; }
        public string EngTitle { get; set; }
        public string Description { get; set; }
        public string MinValuePrice { get; set; }
        public long MaxValueWarrantyTypeId { get; set; }
        public long MaxValueWarrantyAmount { get; set; }
        public bool IsSellingBetweenSellers { get; set; }
        public string Picture { get; set; }
        public string PartNumber { get; set; }
        public string Slug { get; set; }
        public string CreationDate { get; set; }
    }
}
