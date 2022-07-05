using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using AccountManagement.Domain.UserAgg;
using ShopManagement.Application.Contract.Transition;
using ShopManagement.Domain.OrderItemAgg;
using ShopManagement.Domain.TransitionAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class TransitionRepository : BaseRepository<long, Transition>, ITransitionRepository
    {
        private readonly ShopContext _shopContext;
        private readonly IUserRepository _userRepository;


        public TransitionRepository(ShopContext shopContext, IUserRepository userRepository) : base(shopContext)
        {
            _shopContext = shopContext;
            _userRepository = userRepository;
        }

        public List<TransitionViewModel> GetListBySellerPanelId(long sellerPanelId)
        {
            var transitions = _shopContext.Transitions.Select(x => new TransitionViewModel
            {
                Id = x.Id,
                Duration = x.Duration,
                SellerPanelId = x.SellerPanelId,
                TrackingNumber = x.TrackingNumber,
                IsFinished = x.IsFinished,
                TransitionDate = x.CreationDate.ToFarsi()
            }).Where(x => x.SellerPanelId == sellerPanelId).ToList();

            foreach (var transition in transitions)
            {
                var orderItem = _shopContext.OrderItems.FirstOrDefault(x => x.TransitionId == transition.Id);
                var order = _shopContext.Orders.FirstOrDefault(x => x.Id == orderItem.OrderId);
                transition.ReceiverFullName = _userRepository.GetFullNameByUserId(order.UserId);

            }

            return transitions;
        }

        public string GetTrackingNumberById(long id)
        {
            if (id == 0)
                return "";

            return _shopContext.Transitions.Select(x => new { x.TrackingNumber, x.Id })
                .FirstOrDefault(x => x.Id == id)?.TrackingNumber;
        }
    }
}
