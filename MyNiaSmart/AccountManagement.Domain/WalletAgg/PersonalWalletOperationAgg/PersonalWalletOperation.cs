using _0_Framework.Domain;
using AccountManagement.Domain.WalletAgg.OperationTypeAgg;
using AccountManagement.Domain.WalletAgg.PersonalwalletAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.WalletAgg.PersonalWalletOperationAgg
{
    public class Personalwalletoperation:BaseEntity
    {
        public long Amount { get; private set; }
        public bool IsPay { get; private set; }
        public string Description { get; private set; }
        public string VerifyCode { get;private set; }


        //if operation is deposite, the type will save here
        public int DepositeType { get;private set; }

        //to show the status of withdraw operation for client and admin
        public int WithdrawStatus { get; private set; }


        //if operationType is transferation, the reciever full name will save here
        public string ReceiverFullName { get; private set; }

        //if operationType is receiving, the sender FullName will save here
        public string SenderFullName { get; private set; }


        //relations
        public PersonalWallet PersonalWallet { get; private set; }
        public long PersonalWalletId { get; private set; }

        public long WalletOperationTypeId { get; private set; }
        public WalletOperationType WalletOperationType { get;private set; }

        public Personalwalletoperation()
        {

        }
        public Personalwalletoperation(long amount, bool isPay, string description,
            long personalWalletId, long walletOperationTypeId)
        {
            Amount = amount;
            IsPay = isPay;
            Description = description;
            PersonalWalletId = personalWalletId;
            WalletOperationTypeId = walletOperationTypeId;
        }
        public void SetReceiverFullName(string receiverFullName)
        {
            ReceiverFullName = receiverFullName;
        }
        public void SetSenderFullName(string senderFullname)
        {
            SenderFullName = senderFullname;
        }
        public void SetDepositeType(int depositeType)
        {
            DepositeType = depositeType;
        }
        public void GenerateVerifyCode(string verifyCode)
        {
            VerifyCode = verifyCode;
        }
        public void PaymentIsSuccessful()
        {
            IsPay = true;
        }
        public void PaymentIsFailed()
        {
            IsPay=false;
        }
        public void SetWithdrawStatus(int withdrawStatus)
        {
            WithdrawStatus = withdrawStatus;
        }
    }
}
