using _0_Framework.Utilities;
using RepairWorkShopManagement.Application.Contracts.SystemService;
using RepairWorkShopManagement.Domain.ServiceTitleAgg;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using System;
using System.Collections.Generic;

namespace RepairWorkShopManagement.Application
{
    public class SystemServiceApplication : ISystemServiceApplication
    {
        private readonly ISystemServiceRepository _systemServiceRepository;
        private OperationResult operation;
        private readonly IServiceTitleRepository _serviceTitleRepository;

        public SystemServiceApplication(ISystemServiceRepository systemServiceRepository, IServiceTitleRepository serviceTitleRepository)
        {
            _systemServiceRepository = systemServiceRepository;
            operation = new OperationResult();
            _serviceTitleRepository = serviceTitleRepository;
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

        public List<SystemServiceViewModel> GetFilteredListByCategoryIds(FilterSystemServiceViewModel command)
        {
            return _systemServiceRepository.GetFilteredListByCategoryIds(command);
        }

        public SystemServiceViewModel GetInfoById(long id)
        {
            var systemService = _systemServiceRepository.GetById(id);

            var model = new SystemServiceViewModel()
            {
                SystemServiceFarsiTitle = _serviceTitleRepository.GetById(systemService.ServiceTitleId).FarsiTitle,
                
                Id = id,
            };

            return model;
        }

        public List<SystemServiceViewModel> GetList()
        {
            return _systemServiceRepository.GetList();
        }


    }
}
