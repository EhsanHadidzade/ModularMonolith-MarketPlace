using _0_Framework.Utilities;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.UserDeviceAgg;
using RepairWorkShopManagement.Application.Contracts.UserImapairmentReport;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
using RepairWorkShopManagement.Domain.ServiceTitleAgg;
using RepairWorkShopManagement.Domain.SystemServiceAgg;
using RepairWorkShopManagement.Domain.UserImapairmentReportAgg;
using ShopManagement.Domain.ProductAgg;
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
    public class UserImpairmentReportApplication : IUserImpairmentReportApplication
    {
        private readonly IServiceTitleRepository _serviceTitleRepository;
        private readonly OperationResult operation;
        private readonly ISystemServiceRepository _systemServiceRepository;
        private readonly IUserImapairmentReportRepository _userImapairmentReportRepository;
        private readonly IRepairManPanelRepository _repairManPanelRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserDeviceRepository _userDeviceRepository;
        private readonly IUserRepository _userRepository;

        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IProductModelRepository _productModelRepository;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IProductUsageTypeRepository _productUsageTypeRepository;

        public UserImpairmentReportApplication(IUserImapairmentReportRepository userImapairmentReportRepository,
            IServiceTitleRepository serviceTitleRepository, ISystemServiceRepository systemServiceRepository, 
            IProductRepository productRepository, IUserDeviceRepository userDeviceRepository,
            IRepairManPanelRepository repairManPanelRepository, IUserRepository userRepository,
            IProductBrandRepository productBrandRepository, IProductModelRepository productModelRepository,
            IProductTypeRepository productTypeRepository, IProductUsageTypeRepository productUsageTypeRepository)
        {
            _userImapairmentReportRepository = userImapairmentReportRepository;
            _serviceTitleRepository = serviceTitleRepository;
            _systemServiceRepository = systemServiceRepository;
            _productRepository = productRepository;
            _userDeviceRepository = userDeviceRepository;
            _repairManPanelRepository = repairManPanelRepository;
            _userRepository = userRepository;
            operation = new OperationResult();


            _productBrandRepository = productBrandRepository;
            _productModelRepository = productModelRepository;
            _productTypeRepository = productTypeRepository;
            _productUsageTypeRepository = productUsageTypeRepository;
        }

        public OperationResult Create(CreateUserImpairmentReport command)
        {
            if (_userImapairmentReportRepository.IsExist(x => x.UserId == command.UserId && x.UserDeviceId == command.UserDeviceId && x.SystemServiceId == command.SystemServiceId))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var userImpairmentReport = new UserImapairmentReport(command.UserId, command.UserDeviceId,
                command.SystemServiceId, command.Description);

            _userImapairmentReportRepository.Create(userImpairmentReport);
            _userImapairmentReportRepository.Savechange();

            return operation.Succedded();
        }

        public OperationResult Edit(EditUserImpairmentReport command)
        {
            if (_userImapairmentReportRepository.IsExist(x => x.UserId == command.UserId && x.UserDeviceId == command.UserDeviceId && x.SystemServiceId == command.SystemServiceId && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            if (command.UserId == 0)
                return operation.Failed("کاربری یافت نشد");

            var userImpairmentReport = _userImapairmentReportRepository.GetById(command.Id);
            if (userImpairmentReport == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            userImpairmentReport.Edit(command.UserDeviceId, command.SystemServiceId, command.Description);
            _userImapairmentReportRepository.Savechange();

            return operation.Succedded();

        }

        public List<UserImpairmentReportViewModel> GetAll()
        {
            var list = _userImapairmentReportRepository.GetAll();

            var userImairmentReport = ProjectUserImpairmentReport(list);

            return userImairmentReport;

        }

        public List<UserImpairmentReportViewModel> GetAllByRepairManPanelId(int repairManPanelId)
        {
            var list = _userImapairmentReportRepository.GetAllByRepairManPanelId(repairManPanelId);

            var userImairmentReport = ProjectUserImpairmentReport(list);

            return userImairmentReport;
        }

        //public List<UserImpairmentReportViewModel> GetAllByUserId(long userId)
        //{
        //    var list = _userImapairmentReportRepository.GetAllByUserId(userId);

        //    var userImairmentReport = ProjectUserImpairmentReport(list);

        //    return userImairmentReport;
        //}

        public OperationResult AcceptToHandleByRepairManPanelId(long repairManPanelId)
        {
            if (!_repairManPanelRepository.IsExist(x => x.Id == repairManPanelId))
                return operation.Failed(" کاربر گرامی، شما قادر به انجام این عملیات نیستید");

            var userImpairmentReport = _userImapairmentReportRepository.GetById(repairManPanelId);

            userImpairmentReport.AcceptedByRepairMan(repairManPanelId);
            _userImapairmentReportRepository.Savechange();

            return operation.Succedded();

        }


        private List<UserImpairmentReportViewModel> ProjectUserImpairmentReport(List<UserImapairmentReport> list)
        {
            var userImairmentReport = list.Select(x => new UserImpairmentReportViewModel
            {
                Id = x.Id,
                UserDeviceId = x.UserDeviceId,
                SystemServiceId = x.SystemServiceId,
                UserId = x.UserId,
            }).ToList();

            foreach (var item in userImairmentReport)
            {
                var systemService = _systemServiceRepository.GetById(item.SystemServiceId);
                var serviceTitle = _serviceTitleRepository.GetById(systemService.ServiceTitleId);

                var userDevice = _userDeviceRepository.GetById(item.UserDeviceId);
                var userDeviceTitle = _productRepository.GetById(userDevice.ProductId);

                item.SystemServiceTitle = serviceTitle.FarsiTitle;
                item.UserDeviceTitle = userDeviceTitle.FarsiTitle;
                item.UserFullName=_userRepository.GetFullNameByUserId(item.UserId);
            }

            return userImairmentReport;
        }

        public List<UserImpairmentReportViewModel> GetCurrentUserImpairmentReports(long userId)
        {
            var list = _userImapairmentReportRepository.GetCurrentUserImpairmentReports(userId);

            var userImairmentReport = ProjectUserImpairmentReport(list);

            foreach (var item in userImairmentReport)
            {
                var systemService = _systemServiceRepository.GetById(item.SystemServiceId);

                item.BrandFarsiTitle = _productBrandRepository.GetById(systemService.ProductBrandId).FarsiTitle;
                item.ModelFarsiTitle=_productModelRepository.GetById(systemService.ProductModelId).FarsiTitle;
                item.TypeFarsiTitle=_productTypeRepository.GetById(systemService.ProductTypeId).FarsiTitle;
                item.UsageTypeFarsiTitle = _productUsageTypeRepository.GetById(systemService.ProductUsageTypeId).FarsiTitle;
                item.SystemServiceFarsiTitle=_serviceTitleRepository.GetById(systemService.ServiceTitleId).FarsiTitle;
            }

            return userImairmentReport;

        }
    }
}
