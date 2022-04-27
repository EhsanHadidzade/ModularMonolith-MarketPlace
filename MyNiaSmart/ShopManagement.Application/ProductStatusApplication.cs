using _0_Framework.Utilities;
using ShopManagement.Application.Contract.ProductStatus;
using ShopManagement.Domain.ProductStatusAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductStatusApplication : IProductStatusApplication
    {
        private readonly IProductStatusRepository _productStatusRepository;

        public ProductStatusApplication(IProductStatusRepository productStatusRepository)
        {
            _productStatusRepository = productStatusRepository;
        }

        public OperationResult Create(CreateProductStatus command)
        {
            var operation = new OperationResult();
            if (_productStatusRepository.IsExist(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var productStatus = new ProductStatus(command.Title);
            _productStatusRepository.Create(productStatus);
            _productStatusRepository.Savechange();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProductStatus command)
        {
            var operation = new OperationResult();
            var productStatus = _productStatusRepository.GetById(command.Id);
            if (_productStatusRepository.IsExist(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (productStatus == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            productStatus.Edit(command.Title);
            _productStatusRepository.Savechange();
            return operation.Succedded();
        }

        public EditProductStatus GetDetails(int id)
        {
            return _productStatusRepository.GetDetails(id);
        }

        public List<ProductStatusViewModel> GetList()
        {
            return _productStatusRepository.GetList();
        }
    }
}
