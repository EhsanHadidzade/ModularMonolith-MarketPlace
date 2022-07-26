using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.UserDevice;
using AccountManagement.Domain.UserDeviceAgg;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class UserDeviceRepository : BaseRepository<long, UserDevice>, IUserDeviceRepository
    {
        private readonly AccountContext _context;
        

        public UserDeviceRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public List<UserDeviceViewModel> GetListByUserId(long userId)
        {
            var userDevices = _context.UserDevices.Select(x => new UserDeviceViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                ProductId = x.ProductId
            }).Where(x=>x.UserId==userId).OrderByDescending(x => x.Id).ToList();

            return userDevices;
        }
    }
}
