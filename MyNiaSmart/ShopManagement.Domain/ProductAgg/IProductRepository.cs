using _0_Framework.Domain;
using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository:IRepository<long,Product>
    {
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetList();

        //To get title of a product whem slug is passed . using when seller want to search and add new product to his shop
        ProductViewModel GetTitleAndIdById(long id);
    }
}
