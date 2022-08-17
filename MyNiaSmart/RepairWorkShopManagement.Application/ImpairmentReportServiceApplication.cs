using RepairWorkShopManagement.Application.Contracts.ImpairmentReportService;
using RepairWorkShopManagement.Domain.ImpairmentReportServiceAgg;
using RepairWorkShopManagement.Domain.ServiceTitleAgg;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
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
    public class ImpairmentReportServiceApplication : IImpairmentReportServiceApplication
    {
        private readonly IImpairmentReportServiceRepository _impairmentReportServiceRepository;
        private readonly ISystemServiceRepository _systemServiceRepository;
        private readonly IServiceTitleRepository _serviceTitleRepository;

        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IProductModelRepository _productModelRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IProductUsageTypeRepository _productUsageTypeRepository;
        public ImpairmentReportServiceApplication(IImpairmentReportServiceRepository impairmentReportServiceRepository,
            ISystemServiceRepository systemServiceRepository, IServiceTitleRepository serviceTitleRepository, 
            IProductBrandRepository productBrandRepository, IProductModelRepository productModelRepository,
            IProductTypeRepository productTypeRepository, IProductUsageTypeRepository productUsageTypeRepository)
        {
            _impairmentReportServiceRepository = impairmentReportServiceRepository;
            _systemServiceRepository = systemServiceRepository;

            _serviceTitleRepository = serviceTitleRepository;
            _productBrandRepository = productBrandRepository;
            _productModelRepository = productModelRepository;
            _productTypeRepository = productTypeRepository;
            _productUsageTypeRepository = productUsageTypeRepository;
        }

        public List<ImpairmentReportServiceViewModel> GetListByImpairmentReportId(long impairmentReportId)
        {
            var list = new List<ImpairmentReportServiceViewModel>();
            var impairmentReportServices= _impairmentReportServiceRepository.GetAllByQuery(x=>x.UserImpairmentReportId==impairmentReportId);

            foreach (var item in impairmentReportServices)
            {
                var systemService=_systemServiceRepository.GetById(item.SystemServiceId);
                var serviceTitle=_serviceTitleRepository.GetById(systemService.ServiceTitleId).FarsiTitle;
                list.Add(new ImpairmentReportServiceViewModel()
                {
                    Id = item.Id,
                    SystemServiceTitle = serviceTitle,

                    ServiceBrandTitle=_productBrandRepository.GetById(systemService.ProductBrandId).FarsiTitle,
                    ServiceModelTitle=_productModelRepository.GetById(systemService.ProductModelId).FarsiTitle,
                    ServiceTypeTitle=_productTypeRepository.GetById(systemService.ProductTypeId).FarsiTitle,
                    ServiceUsageTypeTitle=_productUsageTypeRepository.GetById(systemService.ProductUsageTypeId).FarsiTitle,
                });
            }

            return list;
        }
    }
}
