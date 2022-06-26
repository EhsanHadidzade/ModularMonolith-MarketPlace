using _0_Framework.Domain;
using ShopManagement.Application.Contract.SellerProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SellerProductAgg
{
    public interface ISellerProductRepository:IRepository<long,SellerProduct>
    {
        EditSellerProduct GetDetails(long sellerProductId);
        
        //to get list of products to show in seller panel of sellers
        List<SellerProductViewModel> GetListBySellerPanelId(long sellerpanelId);

        //To Get All Of them in adminPanel
        List<SellerProductViewModel> GetList();

        // Find Exact SellerProduct then use info to show for sellerProductDetailsView
        EditSellerProduct GetDetailsBySellerPanelIdAndProductId(long sellerPaneId, long productId);

        //To Find any information about the product that seller is selling . using when we need in buying process and showing list of orderItems
        long GetProductIdBySellerProductId(long sellerProductId);

        //to use in order Item Updating while changing item Count By Client
        long GetSellerPriceBySellerproductId(long sellerProductId);



    }
}
