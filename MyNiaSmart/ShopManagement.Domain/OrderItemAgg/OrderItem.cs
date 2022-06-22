using _0_Framework.Domain;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Domain.OrderItemAgg
{
    public class OrderItem : BaseEntity
    {
        public long SellerProductId { get; private set; }
        public int Count { get; private set; }
        public long UnitPrice { get; private set; }

        //relations
        public long OrderId { get; private set; }
        public Order Order { get; private set; }

        public OrderItem(long sellerProductId, int count, long unitPrice, long orderId)
        {
            SellerProductId = sellerProductId;
            Count = count;
            UnitPrice = unitPrice;
            OrderId = orderId;
        }
    }
}
