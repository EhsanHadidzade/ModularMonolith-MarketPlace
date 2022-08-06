using _0_Framework.Infrastructure;
using RepairWorkShopManagement.Domain.UserImapairmentReportAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Repository
{
    public class UserImpairmentReportRepository:BaseRepository<long,UserImapairmentReport>,IUserImapairmentReportRepository
    {
        private readonly RepairWorkShopContext _context;

        public UserImpairmentReportRepository(RepairWorkShopContext context):base(context)
        {
            _context = context;
        }

        public List<UserImapairmentReport> GetAllByRepairManPanelId(int repairManPanelId)
        {
            return _context.UserImapairmentReports.Where(x => x.RepairManPanelId == repairManPanelId).ToList();
        }

        public List<UserImapairmentReport> GetAllByUserId(long userId)
        {
            return _context.UserImapairmentReports.Where(x => x.UserId == userId).ToList();
        }
    }
}
