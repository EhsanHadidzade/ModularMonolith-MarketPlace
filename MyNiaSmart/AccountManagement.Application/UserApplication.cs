using _0_Framework.Utilities;
using _01_Framework.Application;
using AccountManagement.Application.Contract.User;
using AccountManagement.Domain.UserAgg;
using System;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IFileUploader _fileUploader;

        public UserApplication(IUserRepository userRepository, IFileUploader fileUploader)
        {
            _userRepository = userRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateUser command)
        {
            var operation = new OperationResult();
            if (_userRepository.IsExist(x => x.MobileNumber == command.MobileNumber))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var birthday = DateTime.MinValue;
            if (command.Birthday != null)
                birthday = command.Birthday.ToGeorgianDateTime();



            var picturePath = _fileUploader.Upload(command.ProfilePhoto, "UserPhoto");
            var user = new User(command.FullName, command.MobileNumber
                , command.Capital, command.City, command.Address, command.NationalCode
                , birthday, picturePath, command.IntroductorFullname, command.IntroductorMobileNumber);
            _userRepository.Create(user);
            _userRepository.Savechange();

            return operation.Succedded();

        }

        public OperationResult Edit(EditUser command)
        {
            var operation = new OperationResult();
            var user = _userRepository.GetById(command.Id);
            if (user == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_userRepository.IsExist(x => x.MobileNumber == command.MobileNumber && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var birthday = DateTime.MinValue;
            if (command.Birthday != null)
                birthday = command.Birthday.ToGeorgianDateTime();

            var picturePath = _fileUploader.Upload(command.ProfilePhoto, "UserPhoto");

            user.Edit(command.FullName, command.MobileNumber
                , command.Capital, command.City, command.Address, command.NationalCode
                , birthday,picturePath,command.IntroductorFullname,command.IntroductorMobileNumber);
            _userRepository.Savechange();
            return operation.Succedded();
        }

        public EditUser GetDetails(long id)
        {
            return _userRepository.GetDetails(id);
        }

        public List<UserViewModel> GetList()
        {
            return _userRepository.GetList();
        }
    }
}
