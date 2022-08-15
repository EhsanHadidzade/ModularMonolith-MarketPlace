using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RepairWorkShopManagement.Domain.ImpairmentReportProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Repository
{
    public class ImpairmentReportProductRepository : BaseRepository<long, ImpairmentReportProduct>, IImpairmentReportProductRepository
    {
        private readonly RepairWorkShopContext _repairWorkShopContext;
        public ImpairmentReportProductRepository( RepairWorkShopContext repairWorkShopContext) : base(repairWorkShopContext)
        {
            _repairWorkShopContext = repairWorkShopContext;
        }
    }
}
