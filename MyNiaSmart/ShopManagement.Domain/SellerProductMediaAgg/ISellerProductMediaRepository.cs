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


        SellerGalleryViewModel GetMediaById(long id);

        //TO Find the medias that are selected for one product of sellerProducts to show in edit form
        List<long> GetSelectedMediaIdsOfSellerProductBySellerProductIdAndUserId(long sellerProductId, long userId);


        //To Create New Product By Seller and select medias from thait gallery
        void SelectMediaByMediaIds(List<long> mediaIds, long sellerProductId);

        //In Editio of seller product , we use to remove old selected medias 
        void UnSelectMediasByMediaIds(long userId, long sellerProductId);



    }
}
