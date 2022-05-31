using _0_Framework.Infrastructure;
using ShopManagement.Domain.SellerProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SellerProductRepository:BaseRepository<long,SellerProduct>,ISelleProductRepository
    {
        private readonly ShopContext _shopContext;

        public SellerProductRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }
    }
}
