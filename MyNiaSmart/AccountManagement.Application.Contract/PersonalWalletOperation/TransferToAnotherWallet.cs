using _0_Framework.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.PersonalWalletOperation
{
    public class TransferToAnotherWallet
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string DestinationCardNumber { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public long Amount { get; set; }
        public long PersonalWalletId { get; set; }
        public long WalletOperationTypeId { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string VerifyCode { get; set; }
    }
}
