using _0_Framework.Domain;
using ShopManagement.Domain.OrderItemAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.OrderAgg
{
    public class Order : BaseEntity
    {
        public long UserId { get; private set; }
        public long UserAddressId { get; private set; }
        public long TotalAmount { get; private set; }
        public bool IsPaid { get; private set; }
        public bool IsRecievedByUser { get; private set; }
        public DateTime ReceiptDate { get;private set; }
        public DateTime PaymentDate { get;private set; }
        public DateTime CancelDate { get;private set; }
        public bool IsCanceled { get; private set; }
        public int PaymentMethod { get; private set; }
        public string IssueTrackingNo { get; private set; }
        public long RefId { get; private set; }

        //relations
        public List<OrderItem> OrderItems { get; private set; }

        public Order(long userId)
        {
            UserId = userId;
            IsPaid = false;
            IsCanceled = false;
            IsRecievedByUser = false;
            RefId = 0;
            OrderItems = new List<OrderItem>();
        }

        public Order(long userAddressId, long totalAmount)
        {
            TotalAmount = totalAmount;
            UserAddressId = userAddressId;
        }

        //public Order(long userId, long totalAmount, int paymentMethod)
        //{
        //    UserId = userId;
        //    TotalAmount = totalAmount;
        //    PaymentMethod = paymentMethod;
        //    IsPaid = false;
        //    IsCanceled = false;
        //    RefId = 0;
        //    OrderItems = new List<OrderItem>();
        //}

        //After A Succeed Payment For Order , we call this method 
      

        public void SetIssueTrackingNo(string number)
        {
            IssueTrackingNo = number;
        }


        public void SetAsCanceled()
        {
            CancelDate = DateTime.Now;
            IsCanceled = true;
        }
        public void PaymentSucceeded(long refId)
        {
            PaymentDate = DateTime.Now;
            IsPaid = true;

            if (refId != 0)
                RefId = refId;
        }

        public void SetAsRecieved()
        {
            ReceiptDate = DateTime.Now;
            IsRecievedByUser = true;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }

        //Using While Adding new seller Product to current order
        public void IncreaseTotalAmount(long amount)
        {
            TotalAmount = TotalAmount + amount;
        }
        public void UpdateTotalAmount(long totalAmount)
        {
            TotalAmount = totalAmount;
        }

    }
}
