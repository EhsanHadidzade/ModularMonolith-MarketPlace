using AccountManagement.Application.Contract.RejectionReason;
using AccountManagement.Application.Contract.UpAccountRequest;
using AccountManagement.Application.Contract.UpAccountRequestRejectionReason;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UpAccountRequestController : Controller
    {
        private readonly IUPAccountRequestApplication _uPAccountRequestApplication;
        private readonly IUpAccountRequestRejectionReasonApplication _upAccountRequestRejectionReasonApplication;

        public UpAccountRequestController(IUPAccountRequestApplication uPAccountRequestApplication, IUpAccountRequestRejectionReasonApplication upAccountRequestRejectionReasonApplication)
        {
            _uPAccountRequestApplication = uPAccountRequestApplication;
            _upAccountRequestRejectionReasonApplication = upAccountRequestRejectionReasonApplication;
        }

        public IActionResult Index()
        {
            var requests=_uPAccountRequestApplication.GetList();
            return View(requests);
        }

        #region Show And Edit request
        public IActionResult Edit(long id)
        {
            var request = _uPAccountRequestApplication.GetDetails(id);
            return View(request);
        }

        [HttpPost]
        public IActionResult Edit(EditUpAccountRequest command)
        {
            var result = _uPAccountRequestApplication.Edit(command);
            return Redirect("./index");
        }
        #endregion

        #region Confirm a request

        public IActionResult ConfirmByAdmin(long id)
        {
             _uPAccountRequestApplication.ConfirmUpAccountRequestByAdmin(id);
            return Redirect("/administrator/UpAccountRequest/index");
        }
        #endregion

        #region Reject a request with reason
        public IActionResult RejectRequest(long id)
        {
            var model = _uPAccountRequestApplication.GetAllReasonesWithSelectedReasonsOfOneRequestByRequestId(id);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult RejectRequest(List<long> reasons,long requestId)
        {
            var upAccountRequestRejectReasons = new EditUpAccountRequestRejectionReason()
            {
                UpAccountRequestId = requestId,
                SelectedRejectionReasonIds = reasons,
            };

            _upAccountRequestRejectionReasonApplication.EditUpAccountRequestRejectionReasons(upAccountRequestRejectReasons);
            _uPAccountRequestApplication.DeactiveClientConfirmation(requestId);

            return Redirect("./index");
        }
        #endregion


    }
}
