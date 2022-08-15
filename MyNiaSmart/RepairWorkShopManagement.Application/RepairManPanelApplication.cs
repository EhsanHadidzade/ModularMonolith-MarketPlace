using _0_Framework.Utilities;
using RepairWorkShopManagement.Application.Contracts.RepainManPanel;
using RepairWorkShopManagement.Domain.ImpairmentReportServiceAgg;
using RepairWorkShopManagement.Domain.RepairManPanelAgg;
using RepairWorkShopManagement.Domain.RepairManServiceAgg;
using RepairWorkShopManagement.Domain.UserImapairmentReportAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairWorkShopManagement.Application
{
    public class RepairManPanelApplication : IRepairManPanelApplication
    {
        private readonly IRepairManPanelRepository _repairManPanelRepository;
        private readonly IRepairManServiceRepository _repairManServiceRepository;
        private readonly IUserImapairmentReportRepository _userImapairmentReportRepository;
        private readonly IImpairmentReportServiceRepository _impairmentReportServiceRepository;
        private OperationResult operation;

        public RepairManPanelApplication(IRepairManPanelRepository repairManPanelRepository,
            IUserImapairmentReportRepository userImapairmentReportRepository,
            IImpairmentReportServiceRepository impairmentReportServiceRepository, IRepairManServiceRepository repairManServiceRepository)
        {
            _repairManPanelRepository = repairManPanelRepository;
            operation = new OperationResult();
            _userImapairmentReportRepository = userImapairmentReportRepository;
            _impairmentReportServiceRepository = impairmentReportServiceRepository;
            _repairManServiceRepository = repairManServiceRepository;
        }
        public OperationResult Create(CreateRepairManPanel command)
        {
            if (_repairManPanelRepository.IsExist(x => x.CommericalFullName == command.CommericalFullName))
                return operation.Failed("این نام قبلا ثبت شده است . از نام دیگری استفاده نمایید");

            if (_repairManPanelRepository.IsExist(x => x.UserId == command.UserId))
                return operation.Failed("شما قبلا درخواست برای ایجاد پنل تعمیرات پر کرده اید");

            if (command.UserId == 0)
                return operation.Failed("کاربر قابل شناسایی نیست. لطفا با حساب کاربری معتبر وارد شوید");

            var trackingNo = GenerateUniqueCode.GenerateRandomNo();

            var repairManPanel = new RepairManPanel(command.CommericalFullName, command.Capital, command.City,
                command.Address, command.MobileNumber, command.ShortResume,trackingNo, command.CanMarketerSee,
                command.WarrantyTypeId, command.WarrantyAmount, command.UserId);

            _repairManPanelRepository.Create(repairManPanel);
            _repairManPanelRepository.Savechange();
            return operation.Succedded("درخواست شما برای ایجاد پنل همکاری در تعمیرات با موفقیت ثبت شده است. در صورت تایید مدیریت ،  به شما اطلاع رسانی خواهد شد");
        }

        public EditRepairManPanel GetDetails(long id)
        {
            return _repairManPanelRepository.GetDetails(id);
        }

        public List<RepairManPanelViewModel> GetList()
        {
            return _repairManPanelRepository.GetList();
        }

        public OperationResult ConfirmByAdmin(long repairManPanelId)
        {
            var repairManPanel = _repairManPanelRepository.GetById(repairManPanelId);
            if (repairManPanel == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (repairManPanel.IsConfirmedByAdmin)
                return operation.Succedded($"پنل تعمیرات مربوط به {repairManPanel.CommericalFullName} ، قبلا تایید شده بود");


            repairManPanel.ConfirmByAdmin();
            _repairManPanelRepository.Savechange();

            return operation.Succedded($"پنل تعمیرات مربوط به {repairManPanel.CommericalFullName} ، با موفقیت تایید شد");
        }

        public long GetRepairManPanelIdByUserId(long userId)
        {
            var repairManPanelId = _repairManPanelRepository.GetRepairManPanelIdByUserId(userId);
            return repairManPanelId;
        }

        public bool HasUserRequestedForRepairManPanel(long userId)
        {
            return _repairManPanelRepository.HasUserRequestedForRepairManPanel(userId);
        }

        public bool HasUserRepairManPanelConfirmedByAdmin(long userId)
        {
            return _repairManPanelRepository.HasUserRepairManPanelConfirmedByAdmin(userId);
        }

        public List<RepairManPanelViewModel> GetListBasedOnImpairmentReport(long userImpairmentReportId)
        {
            var list = new List<RepairManPanel>();
            //var userImpairmentReport=_userImapairmentReportRepository.GetById(userImpairmentReportId);

            var ImpairmentReportSelectedServiceIds=_impairmentReportServiceRepository.GetAllByQuery(x=>x.UserImpairmentReportId==userImpairmentReportId)
                .Select(x=>x.SystemServiceId).ToList();

            var repairmanPanelIds=_repairManPanelRepository.GetAll().Select(x=>x.Id).Distinct();

            foreach (var repairmanPanelId in repairmanPanelIds)
            {
                var repairManServiceIds=_repairManServiceRepository.GetAllByQuery(x=>x.RepairManPanelId==repairmanPanelId).Select(x=>x.SystemServiceId).ToList();
                
                foreach (var ImpairmentReportSelectedServiceId in ImpairmentReportSelectedServiceIds)
                {
                    if (repairManServiceIds.Any(x => x == ImpairmentReportSelectedServiceId))
                    {
                        var repairmanPanel=_repairManPanelRepository.GetById(repairmanPanelId);
                        list.Add(repairmanPanel);
                    }

                }
            }

            //TODo : Filter RepairMan Which Are not the ImpairmetReport Address Area
            return list.Distinct().Select(x => new RepairManPanelViewModel()
            {
                Id=x.Id,
                CommericalFullName=x.CommericalFullName,
                Capital=x.Capital,
                City=x.City,
                Address=x.Address,
                identityNo=x.IdentityNO
                
            }).ToList();


        }
    }
}
