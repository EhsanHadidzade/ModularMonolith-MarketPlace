using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UpAccountRequestRejectionReasonAgg
{
    public interface IUpAccountRequestRejectionReasonRepository:IRepository<long,UpAccountRequestRejectionReason>
    {
        //To get list of UpAccountRequestRejectionReasons Of one Request . we use them for example in Removing UpAccountRequestRejectionReasons Method
        List<UpAccountRequestRejectionReason> GetUpAccountRequestRejectionReasonsOfOneRequestByRequestId(long requestId);

        //TO remove UpAccountRequestRejectionReasons records of one specific request
        void RemoveUpAccountRequestRejectionReasonsofOneRequestByRequestId(long requestId);

        //TO see if a request is rejected by reason or not to show client their rejection reasons
        bool HasRequestRejectedByReason(long requestId);




    }
}
