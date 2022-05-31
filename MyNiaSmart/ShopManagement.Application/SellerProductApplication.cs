using _0_Framework.Utilities;
using ShopManagement.Application.Contract.SellerProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SellerProductApplication : ISellerProductApplication
    {
        public OperationResult Create(CreateSellerProduct command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditSellerProduct command)
        {
            throw new NotImplementedException();
        }

        public EditSellerProduct GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<SellerProductViewModel> GetList()
        {
            throw new NotImplementedException();
        }
        public void ConfirmByAdmin(long sellerProductId)
        {
            throw new NotImplementedException();
        }
    }
}
