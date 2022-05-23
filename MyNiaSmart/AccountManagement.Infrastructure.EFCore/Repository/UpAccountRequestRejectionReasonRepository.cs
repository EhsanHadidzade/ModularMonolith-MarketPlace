using _0_Framework.Infrastructure;
using AccountManagement.Domain.UpAccountRequestRejectionReasonAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class UpAccountRequestRejectionReasonRepository : BaseRepository<long, UpAccountRequestRejectionReason>, IUpAccountRequestRejectionReasonRepository
    {
        private readonly AccountContext _context;

        public UpAccountRequestRejectionReasonRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public List<UpAccountRequestRejectionReason> GetUpAccountRequestRejectionReasonsOfOneRequestByRequestId(long requestId)
        {
            return _context.UpAccountRequestRejectionReasons.Where(x=>x.UpAccountRequestId == requestId).ToList();
        }

        public void RemoveUpAccountRequestRejectionReasonsofOneRequestByRequestId(long requestId)
        {
            var rejectionReasons=GetUpAccountRequestRejectionReasonsOfOneRequestByRequestId(requestId);
            foreach(var item in rejectionReasons)
            {
                _context.UpAccountRequestRejectionReasons.Remove(item);
                _context.SaveChanges();
            }
        }

        public bool HasRequestRejectedByReason(long requestId)
        {
            var isConfirmedByClient = _context.UpAccountRequests.Select(x => new { x.Id, x.IsRequestConfirmedByClient })
                .FirstOrDefault(x => x.Id == requestId).IsRequestConfirmedByClient;

            if (!isConfirmedByClient && _context.UpAccountRequestRejectionReasons.Any(x => x.UpAccountRequestId == requestId))
                return true;

            return false;

        }
    }
}
