using AccountManagement.Application.Contract.UpAccountRequestRejectionReason;
using AccountManagement.Domain.UpAccountRequestRejectionReasonAgg;
using AccountManagement.Domain.UPAccountRequestsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class UpAccountRequestRejectionReasonApplication : IUpAccountRequestRejectionReasonApplication
    {
        private readonly IUpAccountRequestRejectionReasonRepository _upAccountRequestRejectionReasonRepository;
        private readonly IUPAccountRequestRepository _uPAccountRequestRepository;

        public UpAccountRequestRejectionReasonApplication(IUpAccountRequestRejectionReasonRepository upAccountRequestRejectionReasonRepository,
            IUPAccountRequestRepository uPAccountRequestRepository)
        {
            _upAccountRequestRejectionReasonRepository = upAccountRequestRejectionReasonRepository;
            _uPAccountRequestRepository = uPAccountRequestRepository;
        }

        public void CreateUpAccountRequestRejectionReasons(CreateUpAccountRequestRejectionReason command)
        {
            foreach (var reasonId in command.SelectedRejectionReasonIds)
            {
                var upAccountRequestRejectionReason=new UpAccountRequestRejectionReason(command.UpAccountRequestId, reasonId);
                _upAccountRequestRejectionReasonRepository.Create(upAccountRequestRejectionReason);
                _upAccountRequestRejectionReasonRepository.Savechange();
            }
        }

        public void EditUpAccountRequestRejectionReasons(EditUpAccountRequestRejectionReason command)
        {
            _upAccountRequestRejectionReasonRepository.RemoveUpAccountRequestRejectionReasonsofOneRequestByRequestId(command.UpAccountRequestId);
            foreach (var reasonId in command.SelectedRejectionReasonIds)
            {
                var upAccountRequestRejectionReason = new UpAccountRequestRejectionReason(command.UpAccountRequestId, reasonId);
                _upAccountRequestRejectionReasonRepository.Create(upAccountRequestRejectionReason);
                _upAccountRequestRejectionReasonRepository.Savechange();
            }
        }

        public List<long> GetAllRejectionReasonIdsOfOneUpAccountRequest(long RequestId)
        {
             return _upAccountRequestRejectionReasonRepository.GetUpAccountRequestRejectionReasonsOfOneRequestByRequestId(RequestId).Select(x=>x.RejectionReasonId).ToList();   
        }

        public bool HasRequestRejectedByReason(long requestId)
        {
            return _upAccountRequestRejectionReasonRepository.HasRequestRejectedByReason(requestId);
            
        }

        public void RemoveUpAccountRequestRejectionReasonsofOneUserByUserId(long RequestId)
        {
            _upAccountRequestRejectionReasonRepository.RemoveUpAccountRequestRejectionReasonsofOneRequestByRequestId(RequestId);
        }
    }
}
