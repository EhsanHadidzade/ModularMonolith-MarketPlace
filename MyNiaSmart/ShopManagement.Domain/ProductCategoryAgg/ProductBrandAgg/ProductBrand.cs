using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductModelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg
{
    public class ProductBrand : BaseEntity
    {
        #region Propertied
        public string Title { get; private set; }
        #endregion

        #region Relations
        public List<Product> Products { get; set; }
        public List<ProductModel> ProductModels{ get; private set; }
        #endregion


        public ProductBrand(string title)
        {
            Title = title;
            Products = new List<Product>();
        }
        public void Edit(string title)
        {
            Title = title;
        }
    }
}
