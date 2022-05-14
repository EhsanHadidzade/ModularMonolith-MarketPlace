using _0_Framework.Domain;
using AccountManagement.Application.Contract.RejectionReason;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.RejectionReasonAgg
{
    public interface IRejectionReasonRepository:IRepository<long,RejectionReason>
    {
        List<RejectionReasonViewModel> GetList();
        EditRejectionReason GetDetails(long id);
        RejectionReasonViewModel GetRejectionReasonById(long reasonId);
    }
}
