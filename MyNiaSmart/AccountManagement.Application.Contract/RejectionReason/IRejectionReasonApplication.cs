using _0_Framework.Utilities;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.RejectionReason
{
    public interface IRejectionReasonApplication
    {
        OperationResult Create(CreateRejectionReason command);
        OperationResult Edit(EditRejectionReason command);
        EditRejectionReason GetDetails(long id);
        List<RejectionReasonViewModel> GetList();
        List<RejectionReasonViewModel> GetReasonsOfSpecificUpAccountRequest(long requestId);
    }
}
