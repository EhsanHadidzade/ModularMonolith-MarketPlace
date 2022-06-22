

namespace ShopManagement.Application.Contract.OrderItem
{
    public class CreateOrderItem
    {
        public long SellerProductId { get; set; }
        public int Count { get; set; }
        public long UnitPrice { get; set; }
    }
}