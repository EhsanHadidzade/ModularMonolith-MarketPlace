using _0_Framework.Infrastructure;
using RepairWorkShopManagement.Application.Contracts.ServiceTitle;
using RepairWorkShopManagement.Domain.ServiceTitleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Infrastructure.EFCore.Repository
{
    public class ServiceTitleRepository : BaseRepository<long, ServiceTitle>, IServiceTitleRepository
    {
        private readonly RepairWorkShopContext _context;

        public ServiceTitleRepository(RepairWorkShopContext context):base(context)
        {
            _context = context;
        }

        public EditServiceTitle GetDetails(long id)
        {
            var serviceTitle=_context.ServiceTitles.Select(x=>new EditServiceTitle
            {
                Id=x.Id,
                EngTitle=x.EngTitle,
                FarsiTitle=x.FarsiTitle
            }).FirstOrDefault(x=>x.Id==id);

            return serviceTitle;
        }

        public List<ServiceTitleViewModel> GetList()
        {
            var serviceTitles = _context.ServiceTitles.Select(x => new ServiceTitleViewModel
            {
                Id = x.Id,
                EngTitle = x.EngTitle,
                FarsiTitle = x.FarsiTitle
            }).OrderByDescending(x=>x.Id).ToList();

            return serviceTitles;
        }
    }
}
