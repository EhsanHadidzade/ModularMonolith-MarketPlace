using _0_Framework.Utilities;
using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        public OperationResult Create(CreateProduct command)
        {
            throw new NotImplementedException();
        }

        public OperationResult Edit(EditProduct command)
        {
            throw new NotImplementedException();
        }

        public EditProduct GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
