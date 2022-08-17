using RepairWorkShopManagement.Application.Contracts.ImpairmentReportProduct;
using RepairWorkShopManagement.Domain.ImpairmentReportProductAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductModelAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductTypeAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductUsageTypeAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application
{
    public class ImpairmentReportProductApplication : IImpairmentReportProductApplication
    {
        private readonly IImpairmentReportProductRepository _impairmentReportProductRepository;
        private readonly IProductRepository _productRepository;

        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IProductModelRepository _productModelRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IProductUsageTypeRepository _productUsageTypeRepository;

        public ImpairmentReportProductApplication(IImpairmentReportProductRepository impairmentReportProductRepository,
            IProductRepository productRepository, IProductBrandRepository productBrandRepository,
            IProductModelRepository productModelRepository, IProductTypeRepository productTypeRepository,
            IProductUsageTypeRepository productUsageTypeRepository)
        {
            _impairmentReportProductRepository = impairmentReportProductRepository;
            _productRepository = productRepository;

            _productBrandRepository = productBrandRepository;
            _productModelRepository = productModelRepository;
            _productTypeRepository = productTypeRepository;
            _productUsageTypeRepository = productUsageTypeRepository;
        }

        public List<ImpairmentReportProductViewModel> GetListByImpairmentReportId(long impairmentReportId)
        {
            var list = new List<ImpairmentReportProductViewModel>();
            var impairmentReportProducts = _impairmentReportProductRepository.GetAllByQuery(x => x.UserImpairmentReportId == impairmentReportId);

            foreach (var item in impairmentReportProducts)
            {
                var Product = _productRepository.GetById(item.ProductId);
                list.Add(new ImpairmentReportProductViewModel()
                {
                    Id = item.Id,
                    ProductTitle = Product.FarsiTitle,

                     ServiceBrandTitle = _productBrandRepository.GetById(Product.ProductBrandId).FarsiTitle,
                    ServiceModelTitle = _productModelRepository.GetById(Product.ProductModelId).FarsiTitle,
                    ServiceTypeTitle = _productTypeRepository.GetById(Product.ProductTypeId).FarsiTitle,
                    ServiceUsageTypeTitle = _productUsageTypeRepository.GetById(Product.ProductUsageTypeId).FarsiTitle,
                });
            }

            return list;
        }
    }
}
