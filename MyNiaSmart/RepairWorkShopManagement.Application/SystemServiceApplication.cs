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
            var systemService = new SystemService(command.BaseFeePrice, command.SystemSharePercent, command.WarrantyTypeId,
                command.WarrantyAmount, command.Description, command.Duration, command.ProductBrandId, command.ProductModelId, command.ProductTypeId,
                command.ProductUsageTypeId, command.ServiceTitleId);

            _systemServiceRepository.Create(systemService);
            _systemServiceRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditSystemService command)
        {

            var systemService = _systemServiceRepository.GetById(command.Id);

            if (systemService == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            systemService.Edit(command.BaseFeePrice, command.SystemSharePercent, command.WarrantyTypeId,
                command.WarrantyAmount, command.Description, command.Duration, command.ProductBrandId, command.ProductModelId, command.ProductTypeId,
                command.ProductUsageTypeId, command.ServiceTitleId);

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


    }
}
