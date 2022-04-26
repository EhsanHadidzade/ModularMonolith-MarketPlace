using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductBrandAgg
{
    public interface IProductBrandRepository:IRepository<int,ProductBrand>
    {
        EditProductBrand GetDetails(int id);
        List<ProductBrandViewModel> GetList();
    }
}
