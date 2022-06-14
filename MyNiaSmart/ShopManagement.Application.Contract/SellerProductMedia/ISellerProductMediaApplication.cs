using _0_Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.SellerProductMedia
{
    public interface ISellerProductMediaApplication
    {
        OperationResult CreateMediaForGallery(CreateMediaForSellerGallery command);

        //TO Get list of images that user created and we want to display them in seller panel in product creation form in its specific modal
        List<SellerGalleryViewModel> GetUserGalleryMediasByUserId(long userId);
    }
}
