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
        //Also To Display all files of one user that they added in their Gallery In Admin Panel
        List<SellerGalleryViewModel> GetUserGalleryMediasByUserId(long userId);

        SellerGalleryViewModel GetMediaById(long id);

        //TO Find the medias that are selected for one product of sellerProducts to show in edit form
        List<long> GetSelectedMediaIdsOfSellerProductBySellerProductIdAndUserId(long sellerProductId, long userId);

        //To Create New Product By Seller and select medias from thait gallery
        void SelectMediaByMediaIds(List<long> mediaIds, long sellerProductId);

        //In Editio of seller product , we use to remove old selected medias 
        void UnSelectMediasByMediaIds(long userId, long sellerProductId);

        //To Get all files of one user that they added in their Gallery In Admin Panel
        //List<ManageUserMediaViewModel> GetMediasByUserId(long userId);

        //To Show List Of people who Added medias in their Gallery
        List<long> GetUserIdsWithMedias();

        //To Display Specific Seller Product Medias in AdminPanel
        List<SellerGalleryViewModel> GetSellerMediasBySellerProductId(long sellerProductId);



    }
}
