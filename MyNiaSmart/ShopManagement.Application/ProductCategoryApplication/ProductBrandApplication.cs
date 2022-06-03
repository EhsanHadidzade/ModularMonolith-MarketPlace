using _0_Framework.Utilities;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.ProductCategoryApplication
{
    public class ProductBrandApplication : IProductBrandApplication
    {
        private readonly IProductBrandRepository _productBrandRepository;

        public ProductBrandApplication(IProductBrandRepository productBrandRepository)
        {
            _productBrandRepository = productBrandRepository;
        }

        public OperationResult Create(CreateProductBrand command)
        {
            var operation = new OperationResult();
            if (_productBrandRepository.IsExist(x => x.EngTitle == command.EngTitle))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var productBrand = new ProductBrand(command.EngTitle,command.FarsiTitle);
            _productBrandRepository.Create(productBrand);
            _productBrandRepository.Savechange();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProductBrand command)
        {
            var operation = new OperationResult();
            var productBrand = _productBrandRepository.GetById(command.Id);
            if (_productBrandRepository.IsExist(x => x.EngTitle == command.EngTitle && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (_productBrandRepository.IsExist(x => x.FarsiTitle == command.FarsiTitle && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (productBrand == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            productBrand.Edit(command.EngTitle,command.FarsiTitle);
            _productBrandRepository.Savechange();
            return operation.Succedded();
        }

        public EditProductBrand GetDetails(long id)
        {
            return _productBrandRepository.GetDetails(id);
        }

        public List<ProductBrandViewModel> GetList()
        {
            return _productBrandRepository.GetList();
        }
    }
}
