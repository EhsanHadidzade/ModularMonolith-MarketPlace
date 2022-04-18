using _0_Framework.Utilities;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateRole command)
        {
            var operation = new OperationResult();
            if(_roleRepository.IsExist(x=>x.Name == command.Name))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var role = new Role(command.Name,command.RoleTypeId);
            _roleRepository.Create(role);
            _roleRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditRole command)
        {
            var operation = new OperationResult();
            var role=_roleRepository.GetById(command.Id);
            if(role == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_roleRepository.IsExist(x => x.Name == command.Name && x.Id!=command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            role.Edit(command.Name,command.RoleTypeId);
            _roleRepository.Savechange();
           return operation.Succedded();

        }

        public EditRole getDetails(long id)
        {
          return _roleRepository.GetDetails(id);
        }

        public List<RoleViewModel> GetList()
        {
            return _roleRepository.GetList();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var role= _roleRepository.GetById(id);
            if (role == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            role.Remove();
            _roleRepository.Savechange();
            return operation.Succedded();

        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var role = _roleRepository.GetById(id);
            if (role == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            role.Restore();
            _roleRepository.Savechange();
            return operation.Succedded();
        }
    }
}
