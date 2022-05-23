using _0_Framework.Utilities;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contract.PersonalWalletOperation
{
    public class WithdrawPersonalWallet
    {
        public long PersonalWalletId { get; set; }
        public long WalletOperationTypeId { get; set; }

        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public long Amount { get; set; }
    }
}
