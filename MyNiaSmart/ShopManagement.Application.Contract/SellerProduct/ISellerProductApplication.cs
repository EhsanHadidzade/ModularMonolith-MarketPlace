using _0_Framework.Utilities;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract.SellerProduct
{
    public interface ISellerProductApplication
    {
        OperationResult Create(CreateSellerProduct command);
        OperationResult Edit(EditSellerProduct command);
        EditSellerProduct GetDetails(long id);
        List<SellerProductViewModel> GetList();
        void ConfirmByAdmin(long sellerProductId);
    }
}
