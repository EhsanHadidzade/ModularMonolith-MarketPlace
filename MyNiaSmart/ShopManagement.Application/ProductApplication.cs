using _0_Framework.Utilities;
using _01_Framework.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.IsExist(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var picturePath = _fileUploader.Upload(command.Picture,$"ProductPictures//{command.Title}");

            var product = new Product(command.Title, command.Description, picturePath,
                command.UnitPrice, command.ProductWeight,command.Dimensions,command.CountryMadeIn,
                command.ProductBrandId, command.ProductModelId, command.ProductStatusId, command.ProductTypeId,
                command.ProductUsageTypeId);

            _productRepository.Create(product);
            _productRepository.Savechange();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.IsExist(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);
            var product = _productRepository.GetById(command.Id);

            if(product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            var picturePath = _fileUploader.Upload(command.Picture, $"ProductPictures//{command.Title}");

            product.Edit(command.Title, command.Description, picturePath,
                command.UnitPrice, command.ProductWeight, command.Dimensions, command.CountryMadeIn,
                command.ProductBrandId, command.ProductModelId, command.ProductStatusId, command.ProductTypeId,
                command.ProductUsageTypeId);

            _productRepository.Savechange();
            return operation.Succedded();

        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetList()
        {
            return _productRepository.GetList();
        }
    }
}
