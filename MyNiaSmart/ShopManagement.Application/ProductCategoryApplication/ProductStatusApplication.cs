using _0_Framework.Utilities;
using ShopManagement.Application.Contract.ProductStatus;
using ShopManagement.Domain.ProductCategoryAgg.ProductStatusAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.ProductCategoryApplication
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
            if (_productStatusRepository.IsExist(x => x.EngTitle == command.EngTitle))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var productStatus = new ProductStatus(command.EngTitle,command.FarsiTitle);
            _productStatusRepository.Create(productStatus);
            _productStatusRepository.Savechange();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProductStatus command)
        {
            var operation = new OperationResult();
            var productStatus = _productStatusRepository.GetById(command.Id);
            if (_productStatusRepository.IsExist(x => x.EngTitle == command.EngTitle && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (productStatus == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            productStatus.Edit(command.EngTitle,command.FarsiTitle);
            _productStatusRepository.Savechange();
            return operation.Succedded();
        }

        public EditProductStatus GetDetails(long id)
        {
            return _productStatusRepository.GetDetails(id);
        }

        public List<ProductStatusViewModel> GetList()
        {
            return _productStatusRepository.GetList();
        }
    }
}
