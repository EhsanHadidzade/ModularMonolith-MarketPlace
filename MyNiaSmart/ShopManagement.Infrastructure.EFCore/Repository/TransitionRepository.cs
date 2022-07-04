using _0_Framework.Infrastructure;
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

        public TransitionRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public string GetTrackingNumberById(long id)
        {
            if (id == 0)
                return "";

            return _shopContext.Transitions.Select(x => new { x.TrackingNumber, x.Id }).FirstOrDefault(x => x.Id == id)?.TrackingNumber;
        }
    }
}
