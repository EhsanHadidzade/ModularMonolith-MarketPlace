using _0_Framework.Utilities;
using RepairWorkShopManagement.Application.Contracts.ServiceTitle;
using RepairWorkShopManagement.Domain.ServiceTitleAgg;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application
{
    public class ServiceTitleApplication : IServiceTitleApplication
    {
        private readonly IServiceTitleRepository _serviceTitleRepository;
        private OperationResult operation;

        public ServiceTitleApplication(IServiceTitleRepository serviceTitleRepository)
        {
            _serviceTitleRepository = serviceTitleRepository;
            operation = new OperationResult();
        }

        public OperationResult Create(CreateServiceTitle command)
        {
            if (_serviceTitleRepository.IsExist(x => x.FarsiTitle == command.FarsiTitle))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (_serviceTitleRepository.IsExist(x => x.EngTitle == command.EngTitle))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);


            var serviceTitle = new ServiceTitle(command.EngTitle, command.FarsiTitle);
            _serviceTitleRepository.Create(serviceTitle);
            _serviceTitleRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditServiceTitle command)
        {
            var serviceTitle=_serviceTitleRepository.GetById(command.Id);
            if(serviceTitle == null)    
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_serviceTitleRepository.IsExist(x => x.FarsiTitle == command.FarsiTitle && x.Id!=command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (_serviceTitleRepository.IsExist(x => x.EngTitle == command.EngTitle && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            serviceTitle.Edit(command.EngTitle, command.FarsiTitle);
            _serviceTitleRepository.Savechange();
            return operation.Succedded();

        }

        public EditServiceTitle GetDetails(long id)
        {
            return _serviceTitleRepository.GetDetails(id);
        }

        public List<ServiceTitleViewModel> GetList()
        {
            return _serviceTitleRepository.GetList();
        }
    }
}
