using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductCategory.ProductModel
{
    public class CreateProductModel
    {
        public long ProductBrandId { get; set; }
        public string EngTitle { get; set; }
        public string FarsiTitle { get; set; }
    }
}
