using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductUsageType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductUsageTypeAgg
{
    public interface IProductUsageTypeRepository:IRepository<int,ProductUsageType>
    {
        EditProductUsageType GetDetails(int id);
        List<ProductUsageTypeViewModel> GetList();
    }
}
