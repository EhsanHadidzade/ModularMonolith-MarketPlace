using _0_Framework.Utilities;
using AccountManagement.Application.Contract.UserAddress;
using AccountManagement.Domain.UserAddressAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class UserAddressApplication : IUserAddressApplication
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private OperationResult operation;

        public UserAddressApplication(IUserAddressRepository userAddressRepository)
        {
            _userAddressRepository = userAddressRepository;
            operation = new OperationResult();
        }

        public OperationResult Create(CreateUserAddress command)
        {
            var userAddress = new UserAddress(command.Capital, command.City, command.Address, command.PlaqueNumber,
                command.PostalCode, command.MobileNumber, command.UserId);

            _userAddressRepository.Create(userAddress);
            _userAddressRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditUserAddress command)
        {
            var userAddress = _userAddressRepository.GetById(command.Id);
            if (userAddress == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            userAddress.Edit(command.Capital, command.City, command.Address, command.PlaqueNumber,
                command.PostalCode, command.MobileNumber);
            _userAddressRepository.Savechange();
            return operation.Succedded();
        }

        public EditUserAddress GetDetails(long id)
        {
            return _userAddressRepository.GetDetails(id);
        }

        public List<UserAddressViewModel> GetListByUserId(long userId)
        {
            return _userAddressRepository.GetListByUserId(userId);
        }

        public OperationResult Remove(long userAddressId)
        {
            _userAddressRepository.RemoveById(userAddressId);
            _userAddressRepository.Savechange();
            return operation.Succedded();

        }
    }
}
