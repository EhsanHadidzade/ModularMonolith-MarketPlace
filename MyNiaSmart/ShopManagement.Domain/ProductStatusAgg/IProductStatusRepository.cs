using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductStatusAgg
{
    public interface IProductStatusRepository:IRepository<long,ProductStatus>
    {
        EditProductStatus GetDetails(long id);
        List<ProductStatusViewModel> GetList();
    }
}
