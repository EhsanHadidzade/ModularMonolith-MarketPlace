using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg.ProductModelAgg
{
    public class ProductModel : BaseEntity
    {
        #region Properties

        public string EngTitle { get; private set; }
        public string FarsiTitle { get; private set; }
        #endregion

        #region Relations
        public long ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public List<Product> Products { get; set; }

        #endregion
        public ProductModel(string engTitle,string farsiTitle,long productBrandId)
        {
            EngTitle = engTitle;
            FarsiTitle = farsiTitle;
            ProductBrandId = productBrandId;
            Products = new List<Product>();
        }
        public void Edit(string engTitle,string farsiTitle, long productBrandId)
        {
            EngTitle = engTitle;
            FarsiTitle=farsiTitle;
            ProductBrandId = productBrandId;
        }




    }
}
