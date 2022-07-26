using _0_Framework.Domain;
using AccountManagement.Application.Contract.UserDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UserDeviceAgg
{
    public interface IUserDeviceRepository:IRepository<long,UserDevice>
    {
        List<UserDeviceViewModel> GetListByUserId(long userId);
    }
}
