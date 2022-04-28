using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Application.Contract.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductModelAgg
{
    public interface IProductModelRepository:IRepository<long,ProductModel>
    {
        EditProductModel GetDetails(long id);
        List<ProductModelViewModel> GetList();
    }
}
