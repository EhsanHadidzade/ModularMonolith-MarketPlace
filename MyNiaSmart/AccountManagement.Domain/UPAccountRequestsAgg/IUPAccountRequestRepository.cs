using _0_Framework.Domain;
using AccountManagement.Application.Contract.UpAccountRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.UPAccountRequestsAgg
{
    public interface IUPAccountRequestRepository:IRepository<long,UpAccountRequest>
    {
        EditUpAccountRequest GetDetails(long id);
        bool IsUpAccountRequestConfirmedByAdmin(long userId);
        UpAccountRequestViewModel GetByUserId(long userId);

        //TO Get List of requests in admin panel
        List<UpAccountRequestViewModel> GetList();

        //to see if a user has an upAccountRequest Or not
        bool HasUserRequestedForUpAccount(long userId);

        //to false client confirmation after telling them the rejectionReason
        void DeactiveClientConfirmation(long requestId);

    }
}
