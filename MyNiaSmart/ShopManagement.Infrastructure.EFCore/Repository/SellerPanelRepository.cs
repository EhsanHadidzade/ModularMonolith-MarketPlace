using _0_Framework.Infrastructure;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contract.SellerPanel;
using ShopManagement.Domain.SellerPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SellerPanelRepository:BaseRepository<long,SellerPanel>,ISellerPanelRepository
    {
        private readonly ShopContext _shopContext;
        private readonly IUserRepository _userRepository;


        public SellerPanelRepository(ShopContext shopcontext, IUserRepository userRepository) : base(shopcontext)
        {
            _shopContext = shopcontext;
            _userRepository = userRepository;
        }

        public List<SellerPanelViewModel> GetList()
        {
            return _shopContext.SellerPanels.Select(x=>new SellerPanelViewModel
            {
                Id = x.Id,
                SellerFullName=_userRepository.GetFullNameByUserId(x.UserId),
                StoreMobileNumber=x.StoreMobileNumber,
                StoreName=x.StoreName,
                UserId=x.UserId,
                StoreAddress=x.Address
            }).ToList();
        }
    }
}
