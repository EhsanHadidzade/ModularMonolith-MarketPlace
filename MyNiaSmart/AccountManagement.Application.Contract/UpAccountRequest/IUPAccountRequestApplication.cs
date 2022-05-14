using _0_Framework.Utilities;
using AccountManagement.Application.Contract.RejectionReason;
using System;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.UpAccountRequest
{
    public interface IUPAccountRequestApplication
    {
        OperationResult Create(CreateUpAccountRequest command);
        OperationResult Edit(EditUpAccountRequest command);
        EditUpAccountRequest GetDetails(long id);
        List<UpAccountRequestViewModel> GetList();
        UpAccountRequestViewModel GetByUserId(long userId);



        //To Confirm a request by admin 
        void ConfirmUpAccountRequestByAdmin(long id);

        //to find if a request is confirmed by admin or not
        bool IsUpAccountRequestConfirmedWithAdminByUserId(long userId);

        //to see if a user has an upAccountRequest Or not
        bool HasUserRequestedForUpAccount(long userId);

        //for view in adminpanel to repoert the rejection reason
        Tuple<List<RejectionReasonViewModel>, List<long>, long> GetAllReasonesWithSelectedReasonsOfOneRequestByRequestId(long requestId);

        //to false client confirmation after telling them the rejectionReason
        void DeactiveClientConfirmation(long requestId);



    }
}
