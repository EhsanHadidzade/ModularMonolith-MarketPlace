using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Transition
{
    public class TransitionViewModel
    {
        public long Id { get; set; }
        public string TrackingNumber { get; set; }
        public string ReceiverFullName { get; set; }
        public int Duration { get; set; }
        public long SellerPanelId { get; set; }
        public string TransitionDate { get; set; }
        public bool IsFinished { get; set; }
    }
}
