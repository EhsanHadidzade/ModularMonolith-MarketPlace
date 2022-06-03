using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg.ProductStatusAgg
{
    public class ProductStatus : BaseEntity
    {
        #region Propertied
        public string EngTitle { get; private set; }
        public string FarsiTitle { get; private set; }
        #endregion

        #region Relations
        public List<Product> Products { get; set; }
        #endregion


        public ProductStatus(string engTitle,string farsiTitle)
        {
            EngTitle = engTitle;
            FarsiTitle= farsiTitle;
            Products = new List<Product>();
        }
        public void Edit(string engTitle,string farsiTitle)
        {
            EngTitle = engTitle;
            FarsiTitle = farsiTitle;
        }
    }
}
