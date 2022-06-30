using ShopManagement.Application.Contract.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string RecieverFullName { get; set; }
        public long TotalAmount { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsPaid { get; set; }
        public bool IsRevievedByUser { get; set; }
        public bool IsTransitionPartByPart { get; set; }
        public string PaymentDate { get; set; }
        public string ReceiptDate { get; set; }
        public string CancelDate { get; set; }
        public string IssueTrackingNo { get; set; }
        public long RefId { get; set; }
        public int PaymentMethod { get; set; }
        public List<OrderItemViewModel> orderItems { get; set; }
    }
}
