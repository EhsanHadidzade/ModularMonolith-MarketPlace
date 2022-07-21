using _0_Framework.Infrastructure;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using RepairWorkShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Repository
{
    public class SystemServiceRepository : BaseRepository<long, SystemService>, ISystemServiceRepository
    {
        private readonly RepairWorkShopContext _repairWorkShopContext;
        private readonly ShopContext _shopContext;

        public SystemServiceRepository(RepairWorkShopContext context, ShopContext shopContext) : base(context)
        {
            _repairWorkShopContext = context;
            _shopContext = shopContext;
        }


        public EditSystemService GetDetails(long id)
        {
            var systemService = _repairWorkShopContext.SystemServices.Select(x => new EditSystemService
            {
                Id = x.Id,
                BaseFeePrice = x.BaseFeePrice,
                SystemSharePercent = x.SystemSharePercent,
                WarrantyAmount = x.WarrantyAmount,
                WarrantyTypeId = x.WarrantyTypeId,
                Duration=x.Duration,
                Description=x.Description,

                ProductBrandId = x.ProductBrandId,
                ProductModelId = x.ProductModelId,
                ProductTypeId = x.ProductTypeId,
                ProductUsageTypeId = x.ProductUsageTypeId,
                ServiceTitleId = x.ServiceTitleId,
            }).FirstOrDefault(x => x.Id == id);

            return systemService;
        }

        public List<SystemServiceViewModel> GetList()
        {
            var systemServices = _repairWorkShopContext.SystemServices.Select(x => new SystemServiceViewModel
            {
                Id = x.Id,
                BaseFeePrice = x.BaseFeePrice,
                SystemSharePercent = x.SystemSharePercent,
                Duration = x.Duration,
                WarrantyAmount = x.WarrantyAmount,
                WarrantyTypeId = x.WarrantyTypeId,

                //Fk
                ProductBrandId = x.ProductBrandId,
                ProductModelId = x.ProductModelId,
                ProductTypeId = x.ProductTypeId,
                ServiceTitleId = x.ServiceTitleId,
                ProductUsageTypeId = x.ProductUsageTypeId
            }).OrderByDescending(x => x.Id).ToList();

            foreach (var systemService in systemServices)
            {
                systemService.BrandEngTitle = _shopContext.ProductBrands.FirstOrDefault(x => x.Id == systemService.ProductBrandId).EngTitle;
                systemService.ModelEngTitle = _shopContext.ProductModels.FirstOrDefault(x => x.Id == systemService.ProductModelId).EngTitle;
                systemService.TypeEngTitle = _shopContext.ProductTypes.FirstOrDefault(x => x.Id == systemService.ProductTypeId).EngTitle;
                systemService.UsageTypeEngTitle = _shopContext.ProductUsageTypes.FirstOrDefault(x => x.Id == systemService.ProductUsageTypeId).EngTitle;
                systemService.ServiceTitleEngTitle = _repairWorkShopContext.ServiceTitles.FirstOrDefault(x => x.Id == systemService.ServiceTitleId).EngTitle;
            }

            return systemServices;
        }
    }
}
