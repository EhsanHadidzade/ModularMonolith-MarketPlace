using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using Microsoft.EntityFrameworkCore;
using RepairWorkShopManagement.Application.Contracts.RepairManService;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Repository
{
    public class RepairManServiceRepository : BaseRepository<long, RepairManService>, IRepairManServiceRepository
    {
        private readonly RepairWorkShopContext _context;

        public RepairManServiceRepository(RepairWorkShopContext context) : base(context)
        {
            _context = context;
        }

        public EditRepairManService GetDetails(long id)
        {
            return _context.RepairManServices.Include(
                x => x.SystemService).Select(x => new EditRepairManService
                {
                    Id = x.Id,
                    Price = x.Price,
                    CanMarketerSee = x.CanMarketerSee,
                    MarketerShareAmount = x.MarketerShareAmount,
                    MarketerSharePercent = x.MarketerSharePercent,
                    RepairManPanelId = x.RepairManPanelId,
                    SystemServiceId = x.SystemServiceId,
                    WarrantyAmount = x.WarrantyAmount,
                    WarrantyTypeId = x.WarrantyTypeId,
                }).FirstOrDefault(x => x.Id == id);
        }


        public List<RepairManServiceViewModel> GetList()
        {
            return _context.RepairManServices.Include(x => x.SystemService)
                .Include(x => x.RepairManPanel)
                .Select(x => new RepairManServiceViewModel
                {
                    Id = x.Id,
                    RepairManPanelId = x.RepairManPanelId,
                    SystemServiceId = x.SystemServiceId,
                    IsConfirmedByAdmin = x.IsConfirmedByAdmin,
                    IsEditionConfirmedByAdmin = x.IsEditionConfirmedByAdmin,
                    CreationDate = x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();
        }

        public List<RepairManService> GetListByRepairManPanelId(long repairManPanelId)
        {
            return _context.RepairManServices.Include(x => x.SystemService)
                .Include(x => x.RepairManPanel)
                .Where(x => x.RepairManPanelId == repairManPanelId)
                .OrderByDescending(x => x.Id).ToList();
        }

        public List<long> GetRepairManServiceIds(long repairManPanelId)
        {
            return _context.RepairManServices
                .Where(x => x.RepairManPanelId == repairManPanelId)
                .Select(x => x.SystemServiceId)
                .ToList();
        }
    }
}
