using _0_Framework.Utilities;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Domain.ProductModelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductModelApplication : IProductModelApplication
    {
        private readonly IProductModelRepository _productModelRepository;

        public ProductModelApplication(IProductModelRepository productModelRepository)
        {
            _productModelRepository = productModelRepository;
        }

        public OperationResult Create(CreateProductModel command)
        {
            var operation = new OperationResult();
            if (_productModelRepository.IsExist(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var productModel = new ProductModel(command.Title);
            _productModelRepository.Savechange();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProductModel command)
        {
            var operation = new OperationResult();
            var productModel = _productModelRepository.GetById(command.Id);
            if (_productModelRepository.IsExist(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (productModel == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            productModel.Edit(command.Title);
            _productModelRepository.Savechange();
            return operation.Succedded();
        }

        public EditProductModel GetDetails(int id)
        {
            return _productModelRepository.GetDetails(id);
        }

        public List<ProductModelViewModel> GetList()
        {
            return _productModelRepository.GetList();
        }

    }
}
