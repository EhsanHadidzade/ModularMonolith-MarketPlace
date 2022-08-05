using _0_Framework.Utilities;
using RepairWorkShopManagement.Application.Contracts.RepairManService;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using RepairWorkShopManagement.Domain.ServiceTitleAgg;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductModelAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductTypeAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductUsageTypeAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application
{
    public class RepairManServiceApplication : IRepairManServiceApplication
    {
        private readonly IRepairManServiceRepository _repairManServiceRepository;
        private readonly IRepairManPanelRepository _repairManPanelRepository;
        private readonly ISystemServiceRepository _systemServiceRepository;
        private readonly IProductBrandRepository _productBrandRepository;

        private readonly IProductUsageTypeRepository _productUsageTypeRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IServiceTitleRepository _serviceTitleRepository;
        private readonly IProductModelRepository _productModelRepository;
        private OperationResult operation;

        public RepairManServiceApplication(IRepairManServiceRepository repairManServiceRepository,
            IRepairManPanelRepository repairManPanelRepository, ISystemServiceRepository systemServiceRepository,
            IProductBrandRepository productBrandRepository, IProductModelRepository productModelRepository,
            IProductTypeRepository productTypeRepository, IProductUsageTypeRepository productUsageTypeRepository,
            IServiceTitleRepository serviceTitleRepository)
        {
            _repairManServiceRepository = repairManServiceRepository;
            _repairManPanelRepository = repairManPanelRepository;
            _systemServiceRepository = systemServiceRepository;
            operation = new OperationResult();

            _productBrandRepository = productBrandRepository;
            _productModelRepository = productModelRepository;
            _productTypeRepository = productTypeRepository;
            _productUsageTypeRepository = productUsageTypeRepository;
            _serviceTitleRepository = serviceTitleRepository;
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
            var repairManService=_repairManServiceRepository.GetById(id);
            var relatedSystemService = _systemServiceRepository.GetById(repairManService.SystemServiceId);
            
            var details= new EditRepairManService()
            {
                Id = id,

                Price=repairManService.Price,
                MarketerShareAmount=repairManService.MarketerShareAmount,
                MarketerSharePercent=repairManService.MarketerSharePercent,

                //DefalutValue
                CanMarketerSee=repairManService.CanMarketerSee,
                WarrantyTypeId=repairManService.WarrantyTypeId, 
                WarrantyAmount=repairManService.WarrantyAmount, 

                RepairManPanelId=repairManService.RepairManPanelId,
                SystemServiceId=repairManService.SystemServiceId,
                
                //Categories
                Brand = _productBrandRepository.GetById(relatedSystemService.ProductBrandId).EngTitle,
                Model = _productModelRepository.GetById(relatedSystemService.ProductModelId).EngTitle,
                Type = _productTypeRepository.GetById(relatedSystemService.ProductTypeId).EngTitle,
                UsageType = _productUsageTypeRepository.GetById(relatedSystemService.ProductUsageTypeId).EngTitle,
                SystemServiceTitle = _serviceTitleRepository.GetById(relatedSystemService.ServiceTitleId).EngTitle,
            };

            return details;
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
                var systemService = _systemServiceRepository.GetById(repairManService.SystemServiceId);

                var MyRepairManService = new RepairManServiceViewModel()
                {
                    Id = repairManService.Id,
                    RepairManPanelId = repairManService.RepairManPanelId,
                    Price=repairManService.Price,

                    Brand = _productBrandRepository.GetById(systemService.ProductBrandId).EngTitle,
                    Model = _productModelRepository.GetById(systemService.ProductModelId).EngTitle,
                    Type = _productTypeRepository.GetById(systemService.ProductTypeId).EngTitle,
                    UsageType = _productUsageTypeRepository.GetById(systemService.ProductUsageTypeId).EngTitle,
                    SystemServiceTitle = _serviceTitleRepository.GetById(systemService.ServiceTitleId).EngTitle,
                    CreationDate=repairManService.CreationDate.ToFarsi()

                };

                list.Add(MyRepairManService);
            }

            return list;
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
