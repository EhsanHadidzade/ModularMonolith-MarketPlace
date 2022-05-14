using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.UpAccountRequestRejectionReason
{
    public class CreateUpAccountRequestRejectionReason
    {
        public long UpAccountRequestId { get; set; }
        public List<long> SelectedRejectionReasonIds { get; set; }

    }
}
