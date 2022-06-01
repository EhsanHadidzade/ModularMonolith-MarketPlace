using _0_Framework.Utilities;
using ShopManagement.Application.Contract.ProductBrand;
using ShopManagement.Application.Contract.ProductModel;
using ShopManagement.Domain.ProductCategoryAgg.ProductModelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.ProductCategoryApplication
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

            var productModel = new ProductModel(command.Title, command.ProductBrandId);
            _productModelRepository.Create(productModel);
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

            productModel.Edit(command.Title, command.ProductBrandId);
            _productModelRepository.Savechange();
            return operation.Succedded();
        }

        public EditProductModel GetDetails(long id)
        {
            return _productModelRepository.GetDetails(id);
        }

        public List<ProductModelViewModel> GetFilteredModels(long brandId)
        {
            return _productModelRepository.GetFilteredModels(brandId);
        }

        public List<ProductModelViewModel> GetList()
        {
            return _productModelRepository.GetList();

        }
    }
}
