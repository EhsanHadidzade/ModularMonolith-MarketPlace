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
        public long TotalAmount { get; private set; }
        public bool IsPaid { get; private set; }
        public int PaymentMethod { get; private set; }
        public bool IsCanceled { get; private set; }
        public string IssueTrackingNo { get; private set; }
        public long RefId { get; private set; }

        //relations
        public List<OrderItem> OrderItems { get; private set; }

        public Order(long userId)
        {
            UserId = userId;
            IsPaid = false;
            IsCanceled = false;
            RefId = 0;
            OrderItems = new List<OrderItem>();
        }

        public Order(long userId, long totalAmount, int paymentMethod)
        {
            UserId = userId;
            TotalAmount = totalAmount;
            PaymentMethod = paymentMethod;
            IsPaid = false;
            IsCanceled = false;
            RefId = 0;
            OrderItems = new List<OrderItem>();
        }

        //After A Succeed Payment For Order , we call this method 
        public void PaymentSucceeded(long refId)
        {
            IsPaid = true;

            if (refId != 0)
                RefId = refId;
        }

        public void Cancel()
        {
            IsCanceled = true;
        }

        public void SetIssueTrackingNo(string number)
        {
            IssueTrackingNo = number;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }
    }
}
