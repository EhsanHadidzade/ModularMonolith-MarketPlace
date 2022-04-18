using _0_Framework.Domain;
using AccountManagement.Application.Contract.RoleType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RoleTypeAgg
{
    public interface IRoleTypeRepository:IRepository<long,RoleType>
    {
        EditRoleType GetDetails(long id);
        List<RoleTypeViewModel> GetList();
    }
}
