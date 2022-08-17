using _0_Framework.Contract;
using _0_Framework.Utilities;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Domain.UserDeviceAgg;
using RepairWorkShopManagement.Application.Contracts.UserImapairmentReport;
using RepairWorkShopManagement.Domain.ImpairmentReportProductAgg;
using RepairWorkShopManagement.Domain.ImpairmentReportServiceAgg;
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
        private  OperationResult operation;
        private readonly IUserImapairmentReportRepository _userImapairmentReportRepository;
        private readonly IImpairmentReportServiceRepository _impairmentReportServiceRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IImpairmentReportProductRepository _impairmentReportProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserDeviceRepository _userDeviceRepository;
        private readonly IRepairManPanelRepository _repairManPanelRepository;


        //private readonly IProductBrandRepository _productBrandRepository;
        //private readonly IProductModelRepository _productModelRepository;
        //private readonly IProductTypeRepository _productTypeRepository;
        //private readonly IProductUsageTypeRepository _productUsageTypeRepository;

        public UserImpairmentReportApplication(IUserImapairmentReportRepository userImapairmentReportRepository,
            IImpairmentReportServiceRepository impairmentReportServiceRepository,
            IImpairmentReportProductRepository impairmentReportProductRepository,
            IProductRepository productRepository, IUserDeviceRepository userDeviceRepository,
            IRepairManPanelRepository repairManPanelRepository, IAuthHelper authHelper)
        {


            operation = new OperationResult();
            _userImapairmentReportRepository = userImapairmentReportRepository;
            _impairmentReportServiceRepository = impairmentReportServiceRepository;
            _impairmentReportProductRepository = impairmentReportProductRepository;
            _productRepository = productRepository;
            _userDeviceRepository = userDeviceRepository;
            _repairManPanelRepository = repairManPanelRepository;
            _authHelper = authHelper;
        }

        public OperationResult AddProduct(AddProductToImpairmentReport command)
        {
            var oldImpairmentReportProducts = _impairmentReportProductRepository
               .GetAllByQuery(x => x.UserImpairmentReportId == command.ImpairmentReportId)
               .Select(x => x.Id).ToList();

            if (command.ProductIds.Count == 0)
                return operation.Failed("عملیات امکان پذیر نیست");

            if (oldImpairmentReportProducts.Count() > 0)
            {
                foreach (var oldImpairmentReportProductId in oldImpairmentReportProducts)
                {
                    _impairmentReportProductRepository.RemoveById(oldImpairmentReportProductId);
                    _impairmentReportProductRepository.Savechange();
                }
            }

            foreach (var productId in command.ProductIds)
            {
                var impairmentReportProduct = new ImpairmentReportProduct(command.ImpairmentReportId, productId);
                _impairmentReportProductRepository.Create(impairmentReportProduct);
                _impairmentReportProductRepository.Savechange();
            }

            return operation.Succedded();
        }

        public OperationResult ChooseRepairMan(long repairmanPanelId, long userImpairmentReportId)
        {
            var userImpairmentReport=_userImapairmentReportRepository.GetById(userImpairmentReportId);
            if (userImpairmentReport == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            userImpairmentReport.ChooseRepairManToHandle(repairmanPanelId);
            _userImapairmentReportRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult Create(CreateUserImpairmentReport command)
        {
            if (_userImapairmentReportRepository.IsExist(x => x.UserDeviceId == command.UserDeviceId && !x.IsDone))
                return operation.Failed("یک اعلام خرابی باز برای این دستگاه شما موجود میباشد . تا پایان کار، قادر به اعلام خرابی مجدد برای دستکاه مورد نظر نیستید");

            if (command.SelectedSystemServiceIds.Count == 0)
                return operation.Failed("انتخاب سرویس اجباری است");

            var trackingNo = GenerateUniqueCode.GenerateRandomNo();

            var userImpairmentReport = new UserImapairmentReport(command.UserId, command.UserDeviceId, command.Description, trackingNo);
            _userImapairmentReportRepository.Create(userImpairmentReport);
            _userImapairmentReportRepository.Savechange();

            foreach (var systemServiceId in command.SelectedSystemServiceIds)
            {
                var impairmentReportService = new ImpairmentReportService(userImpairmentReport.Id, systemServiceId);
                _impairmentReportServiceRepository.Create(impairmentReportService);
                _impairmentReportServiceRepository.Savechange();
            }

            return operation.Succedded();

        }

        public OperationResult Edit(EditUserImpairmentReport command)
        {
            if (_userImapairmentReportRepository.IsExist(x => x.UserDeviceId == command.UserDeviceId && !x.IsDone && x.Id != command.Id))
                return operation.Failed("یک اعلام خرابی باز برای این دستگاه شما موجود میباشد . تا پایان کار، قادر به اعلام خرابی مجدد برای دستکاه مورد نظر نیستید");

            var userImpairmentReport = _userImapairmentReportRepository.GetById(command.Id);
            if (userImpairmentReport == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (userImpairmentReport.UserId != command.UserId)
                return operation.Failed("کاربر معتبر نیست");

            userImpairmentReport.Edit(command.UserDeviceId, command.Description);
            _userImapairmentReportRepository.Savechange();

            var oldImppairmentReportServiceIds = _impairmentReportServiceRepository
                .GetAllByQuery(x => x.UserImpairmentReportId == userImpairmentReport.Id)
                .Select(x => x.Id)
                .ToList();

            //Removing Old Record
            if (oldImppairmentReportServiceIds.Count > 0)
            {
                foreach (var oldImpairmentReportServiceId in oldImppairmentReportServiceIds)
                {
                    _impairmentReportServiceRepository.RemoveById(oldImpairmentReportServiceId);
                    _impairmentReportServiceRepository.Savechange();
                }
            }

            //Creating New Records
            foreach (var newImpairmentReportServiceId in command.SelectedSystemServiceIds)
            {
                var impairmentReportService = new ImpairmentReportService(userImpairmentReport.Id, newImpairmentReportServiceId);
                _impairmentReportServiceRepository.Create(impairmentReportService);
                _impairmentReportServiceRepository.Savechange();
            }

            return operation.Succedded();
        }

        public List<UserImpairmentReportViewModel> GetCurrentUserImpairmentReports(long userId)
        {
            var currentUserImpairmentReports = _userImapairmentReportRepository.GetAllByQuery(x => x.UserId == userId && !x.IsDone)
                .Select(x => new UserImpairmentReportViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    IsDone = x.IsDone,
                    UserDeviceId = x.UserDeviceId,
                    IsHandlingByRepairMan = x.IsHandlingByRepairMan,
                    RepairManPanelId = x.RepairManPanelId,
                    CreationDate = x.CreationDate.ToFarsi()
                }).ToList();

            foreach (var item in currentUserImpairmentReports)
            {
                var userDevice = _userDeviceRepository.GetById(item.UserDeviceId);
                var userDeviceTitle = _productRepository.GetById(userDevice.ProductId);

                item.UserDeviceTitle = userDeviceTitle.FarsiTitle;
            }

            return currentUserImpairmentReports;
        }

        public EditUserImpairmentReport GetDetails(long id)
        {
            var impartmentReport = _userImapairmentReportRepository.FirstOrDefaultByQuery(x => x.Id == id);

            var userDevice = _userDeviceRepository.GetById(impartmentReport.UserDeviceId);
            var userDeviceTitle = _productRepository.GetById(userDevice.ProductId);


            var selectedImpartmentReportServiceIds = _impairmentReportServiceRepository
                .GetAllByQuery(x => x.UserImpairmentReportId == impartmentReport.Id)
                .Select(x => x.SystemServiceId).ToList();
            var impairmentDetails = new EditUserImpairmentReport()
            {
                Id = impartmentReport.Id,
                UserId = impartmentReport.UserId,
                Description = impartmentReport.Description,
                UserDeviceId = impartmentReport.UserDeviceId,
                SelectedSystemServiceIds = selectedImpartmentReportServiceIds,
                UserDeviceTitle = userDeviceTitle.FarsiTitle,
                UserDeviceLong=userDevice.Longtitude,
                UserDeviceLatt=userDevice.Latitude,
                UserDeviceAddress=userDevice.Address
            };

            return impairmentDetails;

        }

        public List<UserImpairmentReportViewModel> GetRepairManRelatedReports()
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            if (userId == 0)
                return null;

            var repairmanPanel = _repairManPanelRepository.FirstOrDefaultByQuery(x => x.UserId == userId);
            if (repairmanPanel == null)
                return null;

            
            var list= _userImapairmentReportRepository.GetAllByQuery(x => x.RepairManPanelId == repairmanPanel.Id && x.IsHandlingByRepairMan && !x.IsDone)
                .Select(x => new UserImpairmentReportViewModel()
                {
                    Id = x.Id,
                    TrackingNo = x.TrackingNo,
                    CreationDate = x.CreationDate.ToFarsi(),
                    UserDeviceId = x.UserDeviceId,
                }).OrderByDescending(x=>x.Id).ToList();

            foreach (var item in list)
            {
                var userDevice = _userDeviceRepository.GetById(item.UserDeviceId);
                var userDeviceTitle = _productRepository.GetById(userDevice.ProductId);

                item.UserDeviceTitle = userDeviceTitle.FarsiTitle;
            }

            return list;
        }

        public List<long> GetSelectedProductIds(long userImpairmentReportId)
        {
            return _impairmentReportProductRepository.GetAllByQuery(x => x.UserImpairmentReportId == userImpairmentReportId)
                .Select(x => x.ProductId).ToList();
        }

        public List<UserImpairmentReportViewModel> GetDoneImpairmentReports(long userId)
        {
            var doneImpairmentReports=_userImapairmentReportRepository.GetAllByQuery(x => x.UserId == userId && x.IsDone)
                .Select(x => new UserImpairmentReportViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    IsDone = x.IsDone,
                    UserDeviceId = x.UserDeviceId,
                    IsHandlingByRepairMan = x.IsHandlingByRepairMan,
                    RepairManPanelId = x.RepairManPanelId,
                    CreationDate = x.CreationDate.ToFarsi()
                }).ToList();

            foreach (var item in doneImpairmentReports)
            {
                var userDevice = _userDeviceRepository.GetById(item.UserDeviceId);
                var userDeviceTitle = _productRepository.GetById(userDevice.ProductId);

                item.UserDeviceTitle = userDeviceTitle.FarsiTitle;
            }

            return doneImpairmentReports;
        }

        public List<UserImpairmentReportViewModel> GetRepairmanDoneImpairment(long userId)
        {
            var repairmanPanelId=_repairManPanelRepository.GetRepairManPanelIdByUserId(userId);
            var repairmanDoneImpairment=_userImapairmentReportRepository.GetAllByQuery(x=>x.RepairManPanelId== repairmanPanelId && x.IsDone)
                .Select(x => new UserImpairmentReportViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    IsDone = x.IsDone,
                    UserDeviceId = x.UserDeviceId,
                    IsHandlingByRepairMan = x.IsHandlingByRepairMan,
                    RepairManPanelId = x.RepairManPanelId,
                    CreationDate = x.CreationDate.ToFarsi()
                }).ToList();

            foreach (var item in repairmanDoneImpairment)
            {
                var userDevice = _userDeviceRepository.GetById(item.UserDeviceId);
                var userDeviceTitle = _productRepository.GetById(userDevice.ProductId);

                item.UserDeviceTitle = userDeviceTitle.FarsiTitle;
            }

            return repairmanDoneImpairment;
        }




































        //public OperationResult Create(CreateUserImpairmentReport command)
        //{
        //    if (_userImapairmentReportRepository.IsExist(x => x.UserId == command.UserId && x.UserDeviceId == command.UserDeviceId && x.SystemServiceId == command.SystemServiceId))
        //        return operation.Failed(ApplicationMessage.DuplicatedRecord);

        //    var userImpairmentReport = new UserImapairmentReport(command.UserId, command.UserDeviceId,
        //        command.SystemServiceId, command.Description);

        //    _userImapairmentReportRepository.Create(userImpairmentReport);
        //    _userImapairmentReportRepository.Savechange();

        //    return operation.Succedded();
        //}

        //public OperationResult Edit(EditUserImpairmentReport command)
        //{
        //    if (_userImapairmentReportRepository.IsExist(x => x.UserId == command.UserId && x.UserDeviceId == command.UserDeviceId && x.SystemServiceId == command.SystemServiceId && x.Id != command.Id))
        //        return operation.Failed(ApplicationMessage.DuplicatedRecord);

        //    if (command.UserId == 0)
        //        return operation.Failed("کاربری یافت نشد");

        //    var userImpairmentReport = _userImapairmentReportRepository.GetById(command.Id);
        //    if (userImpairmentReport == null)
        //        return operation.Failed(ApplicationMessage.RecordNotFound);

        //    userImpairmentReport.Edit(command.UserDeviceId, command.SystemServiceId, command.Description);
        //    _userImapairmentReportRepository.Savechange();

        //    return operation.Succedded();

        //}

        //public List<UserImpairmentReportViewModel> GetAll()
        //{
        //    var list = _userImapairmentReportRepository.GetAll();

        //    var userImairmentReport = ProjectUserImpairmentReport(list);

        //    return userImairmentReport;

        //}

        //public List<UserImpairmentReportViewModel> GetAllByRepairManPanelId(int repairManPanelId)
        //{
        //    var list = _userImapairmentReportRepository.GetAllByRepairManPanelId(repairManPanelId);

        //    var userImairmentReport = ProjectUserImpairmentReport(list);

        //    return userImairmentReport;
        //}



        //public OperationResult AcceptToHandleByRepairManPanelId(long repairManPanelId)
        //{
        //    if (!_repairManPanelRepository.IsExist(x => x.Id == repairManPanelId))
        //        return operation.Failed(" کاربر گرامی، شما قادر به انجام این عملیات نیستید");

        //    var userImpairmentReport = _userImapairmentReportRepository.GetById(repairManPanelId);

        //    userImpairmentReport.AcceptedByRepairMan(repairManPanelId);
        //    _userImapairmentReportRepository.Savechange();

        //    return operation.Succedded();

        //}


        //private List<UserImpairmentReportViewModel> ProjectUserImpairmentReport(List<UserImapairmentReport> list)
        //{
        //    var userImairmentReport = list.Select(x => new UserImpairmentReportViewModel
        //    {
        //        Id = x.Id,
        //        UserDeviceId = x.UserDeviceId,
        //        SystemServiceId = x.SystemServiceId,
        //        UserId = x.UserId,
        //    }).ToList();

        //    foreach (var item in userImairmentReport)
        //    {
        //        var systemService = _systemServiceRepository.GetById(item.SystemServiceId);
        //        var serviceTitle = _serviceTitleRepository.GetById(systemService.ServiceTitleId);

        //        var userDevice = _userDeviceRepository.GetById(item.UserDeviceId);
        //        var userDeviceTitle = _productRepository.GetById(userDevice.ProductId);

        //        item.SystemServiceTitle = serviceTitle.FarsiTitle;
        //        item.UserDeviceTitle = userDeviceTitle.FarsiTitle;
        //        item.UserFullName=_userRepository.GetFullNameByUserId(item.UserId);
        //    }

        //    return userImairmentReport;
        //}

        //public List<UserImpairmentReportViewModel> GetCurrentUserImpairmentReports(long userId)
        //{
        //    var list = _userImapairmentReportRepository.GetCurrentUserImpairmentReports(userId);

        //    var userImairmentReport = ProjectUserImpairmentReport(list);

        //    foreach (var item in userImairmentReport)
        //    {
        //        var systemService = _systemServiceRepository.GetById(item.SystemServiceId);

        //        item.BrandFarsiTitle = _productBrandRepository.GetById(systemService.ProductBrandId).FarsiTitle;
        //        item.ModelFarsiTitle=_productModelRepository.GetById(systemService.ProductModelId).FarsiTitle;
        //        item.TypeFarsiTitle=_productTypeRepository.GetById(systemService.ProductTypeId).FarsiTitle;
        //        item.UsageTypeFarsiTitle = _productUsageTypeRepository.GetById(systemService.ProductUsageTypeId).FarsiTitle;
        //        item.SystemServiceFarsiTitle=_serviceTitleRepository.GetById(systemService.ServiceTitleId).FarsiTitle;
        //    }

        //    return userImairmentReport;

        //}
    }
}
