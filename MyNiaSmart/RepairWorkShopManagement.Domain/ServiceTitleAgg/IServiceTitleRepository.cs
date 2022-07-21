using _0_Framework.Domain;
using RepairWorkShopManagement.Application.Contracts.ServiceTitle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Domain.ServiceTitleAgg
{
    public interface IServiceTitleRepository:IRepository<long,ServiceTitle>
    {
        List<ServiceTitleViewModel> GetList();
        EditServiceTitle GetDetails(long id);
    }
}
