using _0_Framework.Domain;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.TransitionAgg;

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

        public long TransitionId { get;private set; }
        //public Transition Transition{ get;private set; }

        public OrderItem()
        {

        }
        public OrderItem(long sellerProductId, int count, long unitPrice, long orderId)
        {
            SellerProductId = sellerProductId;
            Count = count;
            UnitPrice = unitPrice;
            OrderId = orderId;
        }
        public void Update(int count, long unitPrice)
        {
            Count = count;
            UnitPrice = unitPrice;
        }
        public void TransitedBy(long transitionId)
        {
            TransitionId = transitionId;
        }
    }
}
