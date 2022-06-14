using _0_Framework.Domain;
using ShopManagement.Application.Contract.SellerProductMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SellerProductMediaAgg
{
    public interface ISellerProductMediaRepository:IRepository<long,SellerProductMedia>
    {
        //TO Get list of images that user created and we want to display them in seller panel in product creation form in its specific modal
        List<SellerGalleryViewModel> GetUserGalleryMediasByUserId(long userId);

    }
}
