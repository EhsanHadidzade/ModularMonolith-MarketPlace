﻿using _0_Framework.Utilities;
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
        //Also To show list of Medias of one specific user in Admin panel 
        List<SellerGalleryViewModel> GetUserGalleryMediasByUserId(long userId);

        SellerGalleryViewModel GetMediaById(long id);

        //TO Find the medias that are selected for one product of sellerProducts to show in edit form
        List<long> GetSelectedMediaIdsOfSellerProductBySellerProductIdAndUserId(long sellerProductId, long userId);

        //To Remove SelectedMedias From seller Gallery
        OperationResult DeleteSellerMediasByMediaIds(List<long> mediaIds);

        //To Show List of users which have medias i their gallery 
        List<UserWithMediaViewModel> GetUsersWithMedias();


        //To Display Specific Seller Product Medias in AdminPanel
        List<SellerGalleryViewModel> GetSellerMediasBySellerProductId(long sellerProductId);

    }
}
