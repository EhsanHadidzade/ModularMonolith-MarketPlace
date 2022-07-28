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

        //To get title of a product when slug is passed . using when seller want to search and add new product to his shop
        //Or want to get info of specific product information to use in current user  order items 
        ProductViewModel GetInfoById(long id);

        //To get list of all products of admin products and show them to all clients in clientSide with special information coming from sellers
        List<MainShopProductViewModel> GetListForMainShop();

        //To Get Product Details After Selecting im Main Shop
        EditProduct GetDetailsBySlug(string slug);

        
        long GetIdBySlug(string slug);

        //usong when user wants to add their device to theirs in their Profile
        List<ProductViewModel> GetListWithCategories();


    }
}
