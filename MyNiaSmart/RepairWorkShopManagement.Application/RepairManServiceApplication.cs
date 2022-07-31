using _0_Framework.Utilities;
using RepairWorkShopManagement.Application.Contracts.RepairManService;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application
{
    public class RepairManServiceApplication : IRepairManServiceApplication
    {
        private readonly IRepairManPanelRepository _repairManPanelRepository;
        private readonly IRepairManServiceRepository _repairManServiceRepository;
        private readonly ISystemServiceRepository _systemServiceRepository;
        private OperationResult operation;

        public RepairManServiceApplication(IRepairManServiceRepository repairManServiceRepository, IRepairManPanelRepository repairManPanelRepository,
            ISystemServiceRepository systemServiceRepository)
        {
            _repairManServiceRepository = repairManServiceRepository;
            _repairManPanelRepository = repairManPanelRepository;
            _systemServiceRepository = systemServiceRepository;
            operation = new OperationResult();
        }

        public OperationResult Create(CreateRepairManService command)
        {
            var repairManPanel = _repairManPanelRepository.GetById(command.RepairManPanelId);

            if (command.SelectedSystemServiceIds.Count() == 0)
                return operation.Failed("سرویسی انتحاب نشد");

            foreach (var systemServiceId in command.SelectedSystemServiceIds)
            {
                if (_repairManServiceRepository.IsExist(x => x.RepairManPanelId == command.RepairManPanelId && x.SystemServiceId == systemServiceId))
                    return operation.Failed($" شما قبلا توی سرویس : ({command.SystemServiceTitle}) همکاری داشته اید و قادر به همکاری مجدد نیستید");
            }

            foreach (var systemServiceId in command.SelectedSystemServiceIds)
            {
                var systemService = _systemServiceRepository.GetById(systemServiceId);

                //Values From System Service
                command.Price = systemService.BaseFeePrice;
                //Values From RepairMan Panel
                command.CanMarketerSee = repairManPanel.CanMarketerSee;
                command.WarrantyTypeId = repairManPanel.WarrantyTypeId;
                command.WarrantyAmount = repairManPanel.WarrantyAmount;

                var repairManService = new RepairManService(command.Price, command.MarketerSharePercent, command.MarketerShareAmount,
                command.CanMarketerSee, command.WarrantyTypeId, command.WarrantyAmount, command.RepairManPanelId,
                systemServiceId);

                _repairManServiceRepository.Create(repairManService);
                _repairManServiceRepository.Savechange();
            }

            return operation.Succedded($"درخواست شما برای ارائه ی این سرویس({command.SystemServiceTitle}) با موفقیت به ادمین گزارش داده شد و در صورت تایید به شما اطلاع رسانی خواهد شد");
        }

        public OperationResult Edit(EditRepairManService command)
        {
            var repairManService = _repairManServiceRepository.GetById(command.Id);

            if (repairManService == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            repairManService.Edit(command.Price, command.MarketerSharePercent, command.MarketerShareAmount,
                command.CanMarketerSee, command.WarrantyTypeId, command.WarrantyAmount, command.RepairManPanelId,
                command.SystemServiceId);

            _repairManServiceRepository.Savechange();
            return operation.Succedded();
        }

        public EditRepairManService GetDetails(long id)
        {
            return _repairManServiceRepository.GetDetails(id);
        }

        public List<RepairManServiceViewModel> GetList()
        {
            return _repairManServiceRepository.GetList();
        }

        public List<RepairManServiceViewModel> GetListByRepairManPanelId(long repairManPanelId)
        {
            var repairManServices = _repairManServiceRepository.GetListByRepairManPanelId(repairManPanelId);
            var list = new List<RepairManServiceViewModel>();

            foreach (var repairManService in repairManServices)
            {
                var systemService = _systemServiceRepository.GetById(repairManService.Id);

              var  MyRepairManService=new RepairManServiceViewModel()
                {
                  Id = repairManService.Id, 
                  
                }



            }
        }

        public CreateRepairManService PrepareModelForCreationByRepairManPanelId(long repairManPanelId)
        {
            var repairManPanel = _repairManPanelRepository.GetById(repairManPanelId);
            var command = new CreateRepairManService
            {
                CanMarketerSee = repairManPanel.CanMarketerSee,
                WarrantyTypeId = repairManPanel.WarrantyTypeId,
                WarrantyAmount = repairManPanel.WarrantyAmount
            };

            return command;
        }

        public OperationResult ConfirmByAdmin(long repairManServiceId)
        {
            var repairManService = _repairManServiceRepository.GetById(repairManServiceId);
            if (repairManService == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            repairManService.ConfirmEditionByAdmin();
            _repairManServiceRepository.Savechange();
            return operation.Succedded();
        }
    }
}
