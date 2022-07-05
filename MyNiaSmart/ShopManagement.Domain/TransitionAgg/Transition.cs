using _0_Framework.Domain;
using ShopManagement.Domain.OrderItemAgg;
using ShopManagement.Domain.SellerPanelAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.TransitionAgg
{
    public class Transition:BaseEntity
    {
        public string TrackingNumber { get; private set; }
        public int Duration { get; private set; }
        public bool IsFinished { get;private set; }

        //relations
        public long SellerPanelId { get; private set; }
        public SellerPanel SellerPanel { get; private set; }

        //public List<OrderItem> OrderItems{ get; private set; }

        public Transition(long sellerPanelId, string trackingNumber,int duration)
        {
            SellerPanelId = sellerPanelId;
            TrackingNumber = trackingNumber;
            Duration = duration;
            IsFinished=false;
        }
        public void SetAsDone()
        {
            IsFinished = true;
        }
       
    }
}
