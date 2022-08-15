using _0_Framework.Application;
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
            if (_productRepository.IsExist(x => x.FarsiTitle == command.FarsiTitle))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (_productRepository.IsExist(x => x.EngTitle == command.EngTitle))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var picturePath = _fileUploader.Upload(command.Picture,$"ProductPictures//{command.FarsiTitle}");
            var slug = command.Slug.Slugify();

            var product = new Product(command.FarsiTitle,command.EngTitle, command.Description, picturePath,
                command.PartNumber, command.ProductWeight,command.Dimensions,command.CountryMadeIn, slug,
                command.ProductBrandId, command.ProductModelId, command.ProductStatusId, command.ProductTypeId,
                command.ProductUsageTypeId);

            _productRepository.Create(product);
            _productRepository.Savechange();
            return operation.Succedded();

        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.IsExist(x => x.FarsiTitle == command.FarsiTitle && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (_productRepository.IsExist(x => x.EngTitle == command.EngTitle && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var product = _productRepository.GetById(command.Id);
            if(product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            var picturePath = _fileUploader.Upload(command.Picture, $"ProductPictures//{command.FarsiTitle}");
            var slug = command.Slug.Slugify();
            product.Edit(command.FarsiTitle,command.EngTitle, command.Description, picturePath,
                command.PartNumber, command.ProductWeight, command.Dimensions, command.CountryMadeIn,slug,
                command.ProductBrandId, command.ProductModelId, command.ProductStatusId, command.ProductTypeId,
                command.ProductUsageTypeId);

            _productRepository.Savechange();
            return operation.Succedded();

        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public EditProduct GetDetailsBySlug(string slug)
        {
            return _productRepository.GetDetailsBySlug(slug);
        }

        public List<ProductViewModel> GetFilteredByCategories(long brandId, long modelId, long typeId, long usageTypeId)
        {
            var products = _productRepository.GetAllByQuery(x => x.ProductBrandId == brandId
                                                            && x.ProductModelId == modelId 
                                                            && x.ProductTypeId == typeId 
                                                            && x.ProductUsageTypeId == usageTypeId);
            return products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                PictureURL = x.Picture,
                EngTitle = x.EngTitle,
                FarsiTitle = x.FarsiTitle,
                PartNumber = x.PartNumber,
                CreationDate = x.CreationDate.ToFarsi(),
                Slug = x.Slug
            }).ToList();

        }

        public List<ProductViewModel> GetList()
        {
            return _productRepository.GetList();
        }

        public List<MainShopProductViewModel> GetListForMainShop()
        {
            return _productRepository.GetListForMainShop();
        }

        public List<ProductViewModel> GetListWithCategories()
        {
            return _productRepository.GetListWithCategories();
        }

        public ProductViewModel GetTitleAndIdById(long id)
        {
            return _productRepository.GetInfoById(id);
        }
    }
}
