using _0_Framework.Utilities;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Domain.ProductBrandAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
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
            if (_productBrandRepository.IsExist(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var productBrand = new ProductBrand(command.Title);
            _productBrandRepository.Savechange();
            return operation.Succedded();
            
        }

        public OperationResult Edit(EditProductBrand command)
        {
            var operation = new OperationResult();
            var productBrand = _productBrandRepository.GetById(command.Id);
            if (_productBrandRepository.IsExist(x => x.Title == command.Title && x.Id!=command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if(productBrand == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            productBrand.Edit(command.Title);
            _productBrandRepository.Savechange();
            return operation.Succedded();
        }

        public EditProductBrand GetDetails(int id)
        {
            return _productBrandRepository.GetDetails(id);
        }

        public List<ProductBrandViewModel> GetList()
        {
            return _productBrandRepository.GetList();
        }
    }
}
