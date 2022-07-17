using _0_Framework.Infrastructure;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using RepairWorkShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Repository
{
    public class SystemServiceRepository : BaseRepository<long, SystemService>, ISystemServiceRepository
    {
        private readonly RepairWorkShopContext _context;

        public SystemServiceRepository(RepairWorkShopContext context) : base(context)
        {
            _context = context;
        }


        public SystemServiceViewModel GetTitleAndIdById(long systemServiceId)
        {
            var systemService = _context.SystemServices.Select(x => new SystemServiceViewModel
            {
                Id = x.Id,
                FarsiTitle = x.FarsiTitle,
            }).FirstOrDefault(x => x.Id == systemServiceId);

            return systemService;
        }
        public EditSystemService GetDetails(long id)
        {
            var systemService = _context.SystemServices.Select(x => new EditSystemService
            {
                Id = x.Id,
                BaseFeePrice = x.BaseFeePrice,
                EngTitle = x.EngTitle,
                FarsiTitle = x.FarsiTitle,
                SystemSharePercent = x.SystemSharePercent,
                WarrantyAmount = x.WarrantyAmount,
                WarrantyTypeId=x.WarrantyTypeId,
                ProductBrandId = x.ProductBrandId,
                ProductModelId = x.ProductModelId,
                ProductTypeId = x.ProductTypeId,
                ProductUsageTypeId = x.ProductUsageTypeId
            }).FirstOrDefault(x => x.Id == id);

            return systemService;
        }

        public List<SystemServiceViewModel> GetList()
        {
            var systemServices = _context.SystemServices.Select(x => new SystemServiceViewModel
            {
                Id = x.Id,
                EngTitle = x.EngTitle,
                BaseFeePrice = x.BaseFeePrice,
                SystemSharePercent = x.SystemSharePercent
            }).OrderByDescending(x => x.Id).ToList();

            return systemServices;
        }
    }
}
