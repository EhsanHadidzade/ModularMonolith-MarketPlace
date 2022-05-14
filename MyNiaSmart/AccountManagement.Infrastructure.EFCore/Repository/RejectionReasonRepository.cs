using _0_Framework.Infrastructure;
using AccountManagement.Application.Contract.RejectionReason;
using AccountManagement.Domain.RejectionReasonAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class RejectionReasonRepository : BaseRepository<long, RejectionReason>, IRejectionReasonRepository
    {
        private readonly AccountContext _context;

        public RejectionReasonRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public EditRejectionReason GetDetails(long id)
        {
            return _context.RejectionReasons.Select(x => new EditRejectionReason
            {
                Id = x.Id,
                Title = x.Title,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<RejectionReasonViewModel> GetList()
        {
            return _context.RejectionReasons.Select(x => new RejectionReasonViewModel
            {
                Id = x.Id,
                Title = x.Title,
            }).ToList();
        }

        public RejectionReasonViewModel GetRejectionReasonById(long reasonId)
        {
            return _context.RejectionReasons.Select(x=>new RejectionReasonViewModel
            {
                Id=x.Id,
                Title=x.Title,
            }).FirstOrDefault(x=>x.Id == reasonId);
        }
    }
}
