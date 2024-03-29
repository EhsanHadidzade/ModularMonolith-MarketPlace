﻿using _0_Framework.Contract;
using _0_Framework.Infrastructure;
using AccountManagement.Domain.UserAgg;
using AccountManagement.Infrastructure.EFCore;
using ShopManagement.Application.Contract.SellerProductMedia;
using ShopManagement.Domain.SellerProductMediaAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SellerProductMediaRepository : BaseRepository<long, SellerProductMedia>, ISellerProductMediaRepository
    {
        private readonly ShopContext _shopContext;
        private readonly IAuthHelper _authHelper;
        private readonly IUserRepository _userRepository;


        public SellerProductMediaRepository(ShopContext shopContext, IAuthHelper authHelper
                                       , IUserRepository userRepository) : base(shopContext)
        {
            _shopContext = shopContext;
            _authHelper = authHelper;
            _userRepository = userRepository;
        }


        public SellerGalleryViewModel GetMediaById(long id)
        {
            return _shopContext.SellerProductMedias.Select(x => new SellerGalleryViewModel
            {
                Id = x.Id,
                MediaURL = x.MediaURL,
                UserId = x.UserId,
            }).FirstOrDefault(x => x.Id == id);
        }
        public List<SellerGalleryViewModel> GetUserGalleryMediasByUserId(long userId)
        {
            return _shopContext.SellerProductMedias.Select(x => new SellerGalleryViewModel
            {
                Id = x.Id,
                MediaURL = x.MediaURL,
                SellerProductId = x.SellerProductId,
                UserId = x.UserId,
                IsMediaImage=x.IsMediaImage,
                IsSelectedBySeller = true
            }).Where(x => x.UserId == userId).ToList();
        }
        public List<long> GetSelectedMediaIdsOfSellerProductBySellerProductIdAndUserId(long sellerProductId, long userId)
        {
            if (sellerProductId == 0)
                return new List<long>();

            return _shopContext.SellerProductMedias
                .Where(x => x.UserId == userId && x.SellerProductId == sellerProductId)
                .Select(x => x.Id)
                .ToList();
        }
        public void SelectMediaByMediaIds(List<long> mediaIds, long sellerProductId)
        {
            //var userMediaIds = _shopContext.SellerProductMedias.Where(x=> x.SellerProductId == sellerProductId).Select(x => x.Id).ToList();
            if (mediaIds.Count > 0)
            {
                foreach (var id in mediaIds.Where(x => x > 0))
                {
                    var media = _shopContext.SellerProductMedias.Find(id);
                    media.Choose(sellerProductId);
                    _shopContext.SaveChanges();
                }
            }

        }
        public void UnSelectMediasByMediaIds(long userId, long sellerProductId)
        {
            var userMediaIds = _shopContext.SellerProductMedias.Where(x => x.UserId == userId && x.SellerProductId == sellerProductId).Select(x => x.Id).ToList();
            foreach (var id in userMediaIds)
            {
                var media = _shopContext.SellerProductMedias.Find(id);
                media.Choose(0);
                _shopContext.SaveChanges();
            }
        }

        public List<long> GetUserIdsWithMedias()
        {
            return _shopContext.SellerProductMedias.Select(x => x.UserId).Distinct().ToList();
        }

        public List<SellerGalleryViewModel> GetSellerMediasBySellerProductId(long sellerProductId)
        {
            return _shopContext.SellerProductMedias.Select(x => new SellerGalleryViewModel
            {
                Id = x.Id,
                SellerProductId = x.SellerProductId,
                MediaURL = x.MediaURL,
                IsMediaImage = x.IsMediaImage
            }).Where(x => x.SellerProductId == sellerProductId).ToList();

        }
    }
}
