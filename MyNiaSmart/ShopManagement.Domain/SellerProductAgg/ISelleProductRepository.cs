using _0_Framework.Domain;
using ShopManagement.Application.Contract.SellerProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SellerProductAgg
{
    public interface ISelleProductRepository:IRepository<long,SellerProduct>
    {
        EditSellerProduct GetDetails(long sellerProductId);
        List<SellerProductViewModel> GetList();
 
    }
}
