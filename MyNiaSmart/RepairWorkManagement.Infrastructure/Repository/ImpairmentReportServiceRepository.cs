using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RepairWorkShopManagement.Domain.ImpairmentReportServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Repository
{
    
    public class ImpairmentReportServiceRepository : BaseRepository<long, ImpairmentReportService> ,IImpairmentReportServiceRepository
    {
        private readonly RepairWorkShopContext _repairWorkShopContext;

        public ImpairmentReportServiceRepository(RepairWorkShopContext repairWorkShopContext):base(repairWorkShopContext)
        {
            _repairWorkShopContext = repairWorkShopContext;
        }
    }
}
