using _0_Framework.Utilities;
using AccountManagement.Application.Contract.UserDevice;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.UserDeviceAgg;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class UserDeviceApplication : IUserDeviceApplication
    {
        private readonly IUserDeviceRepository _userDeviceRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private OperationResult operation;

        public UserDeviceApplication(IUserDeviceRepository userDeviceRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _userDeviceRepository = userDeviceRepository;
            _productRepository = productRepository;
            operation = new OperationResult();
            _userRepository = userRepository;
        }

        public OperationResult Create(CreateUserDevice command)
        {
            if (_userDeviceRepository.IsExist(x => x.UserId == command.UserId && x.ProductId == command.ProductId))
                return operation.Failed("این دستگاه قبلا به لیست دستگاه های شما اضافه شده است");

            var userDevice = new UserDevice(command.UserId, command.ProductId,command.center_lng,command.center_lat,command.addressValue);
            _userDeviceRepository.Create(userDevice);
            _userDeviceRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditUserDevice command)
        {
            var userDevice = _userDeviceRepository.GetById(command.Id);
            if (userDevice == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (command.UserId == 0 || !_userRepository.IsExist(x=>x.Id==command.UserId))
                return operation.Failed("کاربری یافت نشد");

            if (_userDeviceRepository.IsExist(x => x.UserId == command.UserId && x.ProductId == command.ProductId && x.Id != command.Id))
                return operation.Failed("این دستگاه قبلا به لیست دستگاه های شما اضافه شده است");

            userDevice.Edit(command.ProductId, command.center_lng, command.center_lat, command.addressValue);
            _userDeviceRepository.Savechange();
            return operation.Succedded();
        }

        public EditUserDevice GetDetails(long id)
        {
            return _userDeviceRepository.GetDetails(id);
        }

        public List<UserDeviceViewModel> GetListByUserId(long userId)
        {
            var userDevices = _userDeviceRepository.GetListByUserId(userId);
            foreach (var device in userDevices)
            {
                var product = _productRepository.GetById(device.ProductId);

                device.DevicePictureURL = product.Picture;
                device.DeviceTitle = product.FarsiTitle;
            }

            return userDevices;
        }

        public OperationResult Remove(long id)
        {
            var userDevice = _userDeviceRepository.GetById(id);
            if (userDevice == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            _userDeviceRepository.RemoveById(id);
            _userDeviceRepository.Savechange();

            return operation.Succedded("حذف دستگاه با موفقیت انجام شد");

        }
    }
}
