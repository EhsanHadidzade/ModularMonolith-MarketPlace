using _0_Framework.Utilities;
using RepairWorkShopManagement.Application.Contracts.RepairManService;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
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
        private OperationResult operation;

        public RepairManServiceApplication(IRepairManServiceRepository repairManServiceRepository, IRepairManPanelRepository repairManPanelRepository)
        {
            _repairManServiceRepository = repairManServiceRepository;
            _repairManPanelRepository = repairManPanelRepository;
            operation = new OperationResult();
        }

        public OperationResult Create(CreateRepairManService command)
        {
            if (_repairManServiceRepository.IsExist(x => x.RepairManPanelId == command.RepairManPanelId && x.SystemServiceId == command.SystemServiceId))
                return operation.Failed($" شما قبلا توی سرویس : ({command.SystemServiceTitle}) همکاری داشته اید و قادر به همکاری مجدد نیستید");

            var repairManService = new RepairManService(command.Price, command.MarketerSharePercent, command.MarketerShareAmount,
                command.CanMarketerSee, command.WarrantyTypeId, command.WarrantyAmount, command.RepairManPanelId,
                command.SystemServiceId);

            _repairManServiceRepository.Create(repairManService);
            _repairManServiceRepository.Savechange();
            return operation.Succedded($"درخواست شما برای ارائه ی این سرویس({command.SystemServiceTitle}) با موفقیت به آدمین گزارش داده شد و در صورت تایید به شما اطلاع رسانی خواهد شد");
        }

        public OperationResult Edit(EditRepairManService command)
        {
            var repairManService = _repairManServiceRepository.GetById(command.Id);
            if (repairManService == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_repairManServiceRepository.IsExist(x => x.RepairManPanelId == command.RepairManPanelId && x.SystemServiceId == command.SystemServiceId && x.Id != command.Id))
                return operation.Failed($" شما قبلا توی سرویس : ({command.SystemServiceTitle}) همکاری داشته اید و قادر به همکاری مجدد نیستید");

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
            return _repairManServiceRepository.GetListByRepairManPanelId(repairManPanelId);
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

            repairManService.ConfirmByAdmin();
            _repairManServiceRepository.Savechange();
            return operation.Succedded();
        }
    }
}
