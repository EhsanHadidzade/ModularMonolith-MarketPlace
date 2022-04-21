using _0_Framework.Utilities;
using AccountManagement.Application.Contract.RoleType;
using AccountManagement.Application.Contract.UserRole;
using AccountManagement.Domain.RoleTypeAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class RoleTypeApplication : IRoleTypeApplication
    {
        private readonly IRoleTypeRepository _roleTypeRepository;
        private readonly IUserRoleApplication _userRoleApplication;

        public RoleTypeApplication(IRoleTypeRepository roleTypeRepository, IUserRoleApplication userRoleApplication)
        {
            _roleTypeRepository = roleTypeRepository;
            _userRoleApplication = userRoleApplication;
        }

        public OperationResult Create(CreateRoleType command)
        {
            var operation = new OperationResult();
            if (_roleTypeRepository.IsExist(x => x.RoleTypeName == command.RoleTypeName))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var roleType = new RoleType(command.RoleTypeName);
            _roleTypeRepository.Create(roleType);
            _roleTypeRepository.Savechange();
            return operation.Succedded();

        }

        public OperationResult Edit(EditRoleType command)
        {
            var operation = new OperationResult();
            var roleType = _roleTypeRepository.GetById(command.Id);

            if(_roleTypeRepository.IsExist(x=>x.RoleTypeName == command.RoleTypeName && x.Id!=command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            roleType.Edit(command.RoleTypeName);
            _roleTypeRepository.Savechange();
            return operation.Succedded();
        }

        public Tuple<List<RoleTypeViewModel>, List<long>,long> GetAllRolesWithSelectedRolesOfOneUserByUserId(long userId)
        {
            var AllRoleTypes = GetList();
            var selectedRoles=_userRoleApplication.GetAllRoleIdsOfOneUserByUserId(userId);
            return Tuple.Create<List<RoleTypeViewModel>,List<long>,long>(AllRoleTypes, selectedRoles,userId);
        }

        public EditRoleType getDetails(long id)
        {
            return _roleTypeRepository.GetDetails(id);
        }

        public List<RoleTypeViewModel> GetList()
        {
            return _roleTypeRepository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var roleType = _roleTypeRepository.GetById(id);
            if (roleType == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            roleType.Remove();
            _roleTypeRepository.Savechange();
            return operation.Succedded();

        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var roleType = _roleTypeRepository.GetById(id);
            if (roleType == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            roleType.Restore();
            _roleTypeRepository.Savechange();
            return operation.Succedded();
        }
    }
}
