using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.UserAddress;
using AccountManagement.Domain.UserAddressAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class UserAddressRepository : BaseRepository<long, UserAddress>, IUserAddressRepository
    {
        private readonly AccountContext _context;

        public UserAddressRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public UserAddressViewModel GetUserAddressById(long orderId)
        {
            return _context.UserAddresses.Select(x => new UserAddressViewModel
            {
                Id = x.Id,
                Address = x.Address,
                City = x.City,
                Capital = x.Capital,
                MobileNumber = x.MobileNumber
            }).FirstOrDefault(x => x.Id == orderId);
        }

        public EditUserAddress GetDetails(long id)
        {
            return _context.UserAddresses.Select(x => new EditUserAddress
            {
                Id = x.Id,
                Address = x.Address,
                Capital = x.Capital,
                City = x.City,
                MobileNumber = x.MobileNumber,
                PlaqueNumber = x.PlaqueNumber,
                PostalCode = x.PostalCode,
                UserId = x.UserId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<UserAddressViewModel> GetListByUserId(long userId)
        {
            return _context.UserAddresses.Select(x => new UserAddressViewModel
            {
                Id = x.Id,
                Address = x.Address,
                Capital = x.Capital,
                City = x.City,
                MobileNumber = x.MobileNumber,
                PostalCode = x.PostalCode,
                UserId = x.UserId
            }).Where(x => x.UserId == userId).ToList();
        }
    }
}
