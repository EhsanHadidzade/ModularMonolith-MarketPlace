using _0_Framework.Utilities;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using System;
using System.Collections.Generic;

namespace RepairWorkShopManagement.Application
{
    public class SystemServiceApplication : ISystemServiceApplication
    {
        private readonly ISystemServiceRepository _systemServiceRepository;
        private OperationResult operation;

        public SystemServiceApplication(ISystemServiceRepository systemServiceRepository)
        {
            _systemServiceRepository = systemServiceRepository;
            operation = new OperationResult();
        }

        public OperationResult Create(CreateSystemService command)
        {
            if (_systemServiceRepository.IsExist(x => x.FarsiTitle == command.FarsiTitle))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (_systemServiceRepository.IsExist(x => x.EngTitle == command.EngTitle))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var systemService = new SystemService(command.FarsiTitle, command.EngTitle, command.BaseFeePrice,
                command.SystemSharePercent, command.ProductBrandId, command.ProductModelId, command.ProductTypeId,
                command.ProductUsageTypeId);

            _systemServiceRepository.Create(systemService);
            _systemServiceRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditSystemService command)
        {

            var systemService = _systemServiceRepository.GetById(command.Id);

            if (systemService == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_systemServiceRepository.IsExist(x => x.FarsiTitle == command.FarsiTitle && x.Id!=command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (_systemServiceRepository.IsExist(x => x.EngTitle == command.EngTitle && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            systemService.Edit(command.FarsiTitle, command.EngTitle, command.BaseFeePrice,
                command.SystemSharePercent, command.ProductBrandId, command.ProductModelId, command.ProductTypeId,
                command.ProductUsageTypeId);

            _systemServiceRepository.Savechange();
            return operation.Succedded();
        }

        public EditSystemService GetDetails(long id)
        {
            return _systemServiceRepository.GetDetails(id);
        }

        public List<SystemServiceViewModel> GetList()
        {
            return _systemServiceRepository.GetList();
        }

        public SystemServiceViewModel GetTitleAndIdById(long systemServiceId)
        {
            return _systemServiceRepository.GetTitleAndIdById(systemServiceId);
        }
    }
}
