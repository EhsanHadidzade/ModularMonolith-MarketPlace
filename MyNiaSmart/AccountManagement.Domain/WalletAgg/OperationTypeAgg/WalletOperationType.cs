using _0_Framework.Domain;
using AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.WalletAgg.OperationTypeAgg
{
    public class WalletOperationType:BaseEntity
    {
        public string OperationTypeTitle { get;private set; }

        //relation
        public List<Personalwalletoperation> PersonalWalletOperations { get;private set; }

        public WalletOperationType(long id, string operationTypeTitle)
        {
            Id = id;
            OperationTypeTitle = operationTypeTitle;
            PersonalWalletOperations = new List<Personalwalletoperation>();
        }
    }
}
