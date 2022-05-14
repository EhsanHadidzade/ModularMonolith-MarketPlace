using System.Collections.Generic;

namespace AccountManagement.Application.Contract.UpAccountRequestRejectionReason
{
    public interface IUpAccountRequestRejectionReasonApplication
    {
        void CreateUpAccountRequestRejectionReasons(CreateUpAccountRequestRejectionReason command);
        void EditUpAccountRequestRejectionReasons(EditUpAccountRequestRejectionReason command);

        //To get list of UpAccountRequest RejectionReasonIds for show in edit form
        List<long> GetAllRejectionReasonIdsOfOneUpAccountRequest(long RequestId);



        //TO remove UpAccountRequestRejectionReason records of one specific UpAccountRequest
        void RemoveUpAccountRequestRejectionReasonsofOneUserByUserId(long RequestId);

        //TO see if a request is rejected by reason or not to show client their rejection reasons
        bool HasRequestRejectedByReason(long requestId);
    }
}
