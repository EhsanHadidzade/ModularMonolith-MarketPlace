using _0_Framework.Domain;
using AccountManagement.Domain.RejectionReasonAgg;
using AccountManagement.Domain.UPAccountRequestsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UpAccountRequestRejectionReasonAgg
{
    public class UpAccountRequestRejectionReason:BaseEntity
    {
        public long UpAccountRequestId { get; private set; }
        public long RejectionReasonId { get; private set; }

        //Relations
        public UpAccountRequest UpAccountRequest { get; set; }
        public RejectionReason RejectionReason{ get; set; }

        public UpAccountRequestRejectionReason(long upAccountRequestId, long rejectionReasonId)
        {
            UpAccountRequestId = upAccountRequestId;
            RejectionReasonId = rejectionReasonId;
        }

        public void Edit(long upAccountRequestId, long rejectionReasonId)
        {
            UpAccountRequestId = upAccountRequestId;
            RejectionReasonId = rejectionReasonId;
        }
    }
}
