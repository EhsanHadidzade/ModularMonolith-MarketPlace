using _0_Framework.Infrastructure;
using RepairWorkShopManagement.Application.Contracts.RepainManPanel;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Repository
{
    public class RepairManPanelRepository : BaseRepository<long, RepairManPanel>, IRepairManPanelRepository
    {
        private readonly RepairWorkShopContext _context;

        public RepairManPanelRepository(RepairWorkShopContext context) : base(context)
        {
            _context = context;
        }
        public EditRepairManPanel GetDetails(long id)
        {
            var repairManPanel = _context.RepairManPanels.Select(x => new EditRepairManPanel
            {
                Id = x.Id,
                CommericalFullName = x.CommericalFullName,
                MobileNumber = x.MobileNumber,
                ShortResume = x.ShortResume,
                UserId = x.UserId,
                Capital = x.Capital,
                City = x.City,
                Address = x.Address,
                CanMarketerSee = x.CanMarketerSee,
                WarrantyAmount = x.WarrantyAmount,
                WarrantyTypeId = x.WarrantyTypeId,
            }).FirstOrDefault(x => x.Id == id);

            return repairManPanel;
        }

        public List<RepairManPanelViewModel> GetList()
        {
            var repairManPanels = _context.RepairManPanels.Select(x => new RepairManPanelViewModel
            {
                Id = x.Id,
                Capital = x.Capital,
                City = x.City,
                CommericalFullName = x.CommericalFullName,
                IsConfirmedByAdmin = x.IsConfirmedByAdmin,

            }).OrderByDescending(x=>x.Id).ToList();

            return repairManPanels;

        }

        public long GetRepairManPanelIdByUserId(long userId)
        {
            var repairManPanel= _context.RepairManPanels.Select(x => new {x.UserId,x.Id}).FirstOrDefault(x => x.UserId == userId);
            if(repairManPanel != null)
            return repairManPanel.Id;

            return 0;
        }

        public bool HasUserRepairManPanelConfirmedByAdmin(long userId)
        {
            var repairManPanelRequest = _context.RepairManPanels.FirstOrDefault(x => x.UserId == userId && x.IsConfirmedByAdmin);
            return repairManPanelRequest != null;
        }

        public bool HasUserRequestedForRepairManPanel(long userId)
        {
            return _context.RepairManPanels.Any(x=>x.UserId == userId);
        }
    }
}
