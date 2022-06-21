using _0_Framework.Contract;
using _0_Framework.Utilities;
using _01_Framework.Application;
using AccountManagement.Domain.UserAgg;
using ShopManagement.Application.Contract.SellerProductMedia;
using ShopManagement.Domain.SellerProductMediaAgg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SellerProductMediaApplication : ISellerProductMediaApplication
    {
        private readonly ISellerProductMediaRepository _sellerProductMediaRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IFileUploader _fileUploader;


        public SellerProductMediaApplication(ISellerProductMediaRepository sellerProductMediaRepository,
            IAuthHelper authHelper, IFileUploader fileUploader, IUserRepository userRepository)
        {
            _sellerProductMediaRepository = sellerProductMediaRepository;
            _authHelper = authHelper;
            _fileUploader = fileUploader;
            _userRepository = userRepository;
        }

        public List<UserWithMediaViewModel> GetUsersWithMedias()
        {
            var UsersWithMedias = new List<UserWithMediaViewModel>();
            var UserIdsWithMedias = _sellerProductMediaRepository.GetUserIdsWithMedias();

            foreach (var userId in UserIdsWithMedias)
            {
                var userMobileNumber = _userRepository.GetMobileNumberByUserId(userId);
                var user = new UserWithMediaViewModel
                {
                    UserId = userId,
                    UserFullName = _userRepository.GetFullNameByUserId(userId),
                    UserMediaDiskSpace = _fileUploader.GetDiskSpaceByPath($"SellerProductMedias//{userMobileNumber}"),
                    PictureCount = _sellerProductMediaRepository.GetUserGalleryMediasByUserId(userId).Where(x => x.IsMediaImage).Count(),
                    VideoCount = _sellerProductMediaRepository.GetUserGalleryMediasByUserId(userId).Where(x => !x.IsMediaImage).Count(),

                };
                UsersWithMedias.Add(user);
            }

            return UsersWithMedias;
        }

        public OperationResult CreateMediaForGallery(CreateMediaForSellerGallery command)
        {
            var operation = new OperationResult();
            var userMobile = _authHelper.CurrentAccountInfo().Mobile;
            var userId = _authHelper.CurrentAccountInfo().Id;

            //TO Do : check extension of files that are uploading and return error to client if its not png or jpg or video
            var extention = Path.GetExtension(command.Media.FileName);
            if (extention == ".png" || extention == ".jpg")
            {
                var picturePath = _fileUploader.Upload(command.Media, $"SellerProductMedias//{userMobile}");
                var sellerProductMedia = new SellerProductMedia(picturePath, userId);
                _sellerProductMediaRepository.Create(sellerProductMedia);
                _sellerProductMediaRepository.Savechange();

                //To DO :  We should Check if upload file is image or vieo then Select isMediaImage
                return operation.SucceddedWithId("آپلود موفقیت آمیز بود", sellerProductMedia.Id);
            }
            return operation.Failed("باید png و یا jpg باشد");
        }

        public OperationResult DeleteSellerMediasByMediaIds(List<long> mediaIds)
        {
            var operation = new OperationResult();
            foreach (var mediaId in mediaIds.Where(x => x > 0))
            {
                //TO Remove From Static Files
                var media = _sellerProductMediaRepository.GetMediaById(mediaId);
                _fileUploader.RemovePicture(media.MediaURL);

                _sellerProductMediaRepository.RemoveById(mediaId);
            }
            _sellerProductMediaRepository.Savechange();
            return operation.Succedded("حذف با موفقیت انجام شد");
        }

        public SellerGalleryViewModel GetMediaById(long id)
        {
            return _sellerProductMediaRepository.GetMediaById(id);
        }

        public List<long> GetSelectedMediaIdsOfSellerProductBySellerProductIdAndUserId(long sellerProductId, long userId)
        {
            return _sellerProductMediaRepository.GetSelectedMediaIdsOfSellerProductBySellerProductIdAndUserId(sellerProductId, userId);
        }

        public List<SellerGalleryViewModel> GetUserGalleryMediasByUserId(long userId)
        {
            return _sellerProductMediaRepository.GetUserGalleryMediasByUserId(userId);
        }

        public List<SellerGalleryViewModel> GetSellerMediasBySellerProductId(long sellerProductId)
        {
            return _sellerProductMediaRepository.GetSellerMediasBySellerProductId(sellerProductId);
        }
    }
}
