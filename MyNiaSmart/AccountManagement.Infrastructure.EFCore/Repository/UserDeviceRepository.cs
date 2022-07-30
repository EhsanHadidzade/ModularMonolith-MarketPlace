using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
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
        private readonly IProductRepository _productRepository;


        public UserDeviceRepository(AccountContext context, IProductRepository productRepository) : base(context)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public EditUserDevice GetDetails(long id)
        {
            var userDevice = _context.UserDevices.Select(x => new EditUserDevice
            {
                Id = x.Id,
                UserId = x.UserId,
                ProductId = x.ProductId,
                center_lat = x.Latitude,
                center_lng = x.Longtitude,
                addressValue = x.Address
            }).FirstOrDefault(x => x.Id == id);

            userDevice.deviceTitle = _productRepository.GetInfoById(userDevice.ProductId).FarsiTitle;

            return userDevice;
        }

        public List<UserDeviceViewModel> GetListByUserId(long userId)
        {
            var userDevices = _context.UserDevices.Select(x => new UserDeviceViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                ProductId = x.ProductId,
                Address = x.Address,
                CreationDate=x.CreationDate.ToFarsi()
            }).Where(x=>x.UserId==userId).OrderByDescending(x => x.Id).ToList();

            return userDevices;
        }
    }
}
