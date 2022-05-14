using _0_Framework.Domain;
using AccountManagement.Domain.UpAccountRequestRejectionReasonAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RejectionReasonAgg
{
    public class RejectionReason:BaseEntity
    {
        public string Title { get; private set; }


        //relations
        public List<UpAccountRequestRejectionReason> UpAccountRequestRejectionReasons { get; set; }
        public RejectionReason(string title)
        {
            Title = title;
        }
        public void Edit(string title)
        {
            Title = title;
        }
    }
}
