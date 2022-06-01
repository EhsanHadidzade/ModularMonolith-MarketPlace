using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductModel
{
    public class CreateProductModel
    {
        public long ProductBrandId { get; set; }
        public string Title { get; set; }
    }
}
