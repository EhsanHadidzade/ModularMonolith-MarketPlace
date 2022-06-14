using _0_Framework.Contract;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.SellerProductMedia;
using ShopManagement.Domain.SellerProductMediaAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SellerProductMediaRepository:BaseRepository<long,SellerProductMedia>,ISellerProductMediaRepository
    {
        private readonly ShopContext _shopContext;
        private readonly IAuthHelper _authHelper;

        public SellerProductMediaRepository(ShopContext shopContext, IAuthHelper authHelper) : base(shopContext)
        {
            _shopContext = shopContext;
            _authHelper = authHelper;
        }

        public List<SellerGalleryViewModel> GetUserGalleryMediasByUserId(long userId)
        {
            return _shopContext.SellerProductMedias.Select(x => new SellerGalleryViewModel
            {
                Id = x.Id,
                MediaURL = x.MediaURL,
                SellerProductId=x.SellerProductId,
                UserId=x.UserId,
                IsSelectedBySeller = true
            }).Where(x=>x.UserId==userId).ToList();
        }
    }
}
