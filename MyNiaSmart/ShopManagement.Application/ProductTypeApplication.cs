using _0_Framework.Utilities;
using ShopManagement.Application.Contract.ProductType;
using ShopManagement.Domain.ProductTypeAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductTypeApplication : IProductTypeApplication
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeApplication(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public OperationResult Create(CreateProductType command)
        {
            var operation = new OperationResult();
            if (_productTypeRepository.IsExist(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var productType = new ProductType(command.Title);
            _productTypeRepository.Create(productType);
            _productTypeRepository.Savechange();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProductType command)
        {
            var operation = new OperationResult();
            var productType = _productTypeRepository.GetById(command.Id);
            if (_productTypeRepository.IsExist(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (productType == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            productType.Edit(command.Title);
            _productTypeRepository.Savechange();
            return operation.Succedded();
        }

        public EditProductType GetDetails(long id)
        {
            return _productTypeRepository.GetDetails(id);
        }

        public List<ProductTypeViewModel> GetList()
        {
            return _productTypeRepository.GetList();
        }
    }
}
