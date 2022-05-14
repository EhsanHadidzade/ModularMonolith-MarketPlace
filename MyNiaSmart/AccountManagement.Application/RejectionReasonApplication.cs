using _0_Framework.Utilities;
using AccountManagement.Application.Contract.RejectionReason;
using AccountManagement.Domain.RejectionReasonAgg;
using AccountManagement.Domain.UpAccountRequestRejectionReasonAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application
{
    public class RejectionReasonApplication : IRejectionReasonApplication
    {
        private readonly IRejectionReasonRepository _rejectionReasonRepository;
        private readonly IUpAccountRequestRejectionReasonRepository _upAccountRequestRejectionReasonRepository;

        public RejectionReasonApplication(IRejectionReasonRepository rejectionReasonRepository, IUpAccountRequestRejectionReasonRepository upAccountRequestRejectionReasonRepository)
        {
            _rejectionReasonRepository = rejectionReasonRepository;
            _upAccountRequestRejectionReasonRepository = upAccountRequestRejectionReasonRepository;
        }

        public OperationResult Create(CreateRejectionReason command)
        {
            var operation = new OperationResult();
            var rejectionReason = new RejectionReason(command.Title);
            if (_rejectionReasonRepository.IsExist(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            _rejectionReasonRepository.Create(rejectionReason);
            _rejectionReasonRepository.Savechange();
            return operation.Succedded();
        }

        public OperationResult Edit(EditRejectionReason command)
        {
            var operation = new OperationResult();

            var rejectionReason = _rejectionReasonRepository.GetById(command.Id);

            if (_rejectionReasonRepository.IsExist(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (rejectionReason == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            rejectionReason.Edit(command.Title);
            _rejectionReasonRepository.Savechange();
            return operation.Succedded();
        }

       
        public EditRejectionReason GetDetails(long id)
        {
            return _rejectionReasonRepository.GetDetails(id);
        }

        public List<RejectionReasonViewModel> GetList()
        {
            return _rejectionReasonRepository.GetList();
        }

        public List<RejectionReasonViewModel> GetReasonsOfSpecificUpAccountRequest(long requestId)
        {
            var specificReasonIds=_upAccountRequestRejectionReasonRepository.GetUpAccountRequestRejectionReasonsOfOneRequestByRequestId(requestId).Select(x => x.RejectionReasonId);
            var reasons = new List<RejectionReasonViewModel>();
            foreach (var reasonId in specificReasonIds)
            {
               var reasonViewModel= _rejectionReasonRepository.GetRejectionReasonById(reasonId);
                reasons.Add(reasonViewModel);
            }
            return reasons;
            
        }

    }
}
