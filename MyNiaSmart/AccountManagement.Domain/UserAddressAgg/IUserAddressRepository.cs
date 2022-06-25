using _0_Framework.Domain;
using AccountManagement.Application.Contract.UserAddress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UserAddressAgg
{
    public interface IUserAddressRepository:IRepository<long,UserAddress>
    {
        EditUserAddress GetDetails(long id);
        List<UserAddressViewModel> GetListByUserId(long userId);
    }
}
