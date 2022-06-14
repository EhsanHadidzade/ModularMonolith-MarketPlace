using _0_Framework.Contract;
using _0_Framework.Utilities;
using _01_Framework.Application;
using ShopManagement.Application.Contract.SellerProductMedia;
using ShopManagement.Domain.SellerProductMediaAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SellerProductMediaApplication : ISellerProductMediaApplication
    {
        private readonly ISellerProductMediaRepository _sellerProductMediaRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IFileUploader _fileUploader;

        public SellerProductMediaApplication(ISellerProductMediaRepository sellerProductMediaRepositoryl,
            IAuthHelper authHelper)
        {
            _sellerProductMediaRepository = sellerProductMediaRepositoryl;
            _authHelper = authHelper;
        }

        public OperationResult CreateMediaForGallery(CreateMediaForSellerGallery command)
        {
            var operation = new OperationResult();
            var userMobile = _authHelper.CurrentAccountInfo().Mobile;
            var userId = _authHelper.CurrentAccountInfo().Id;

            //TO Do : check extension of files that are uploading and return error to client if its not png or jpg or video

            var picturePath = _fileUploader.Upload(command.Media, $"SellerProductPictures//{userMobile}");
            var sellerProductMedia = new SellerProductMedia(picturePath, userId);
            _sellerProductMediaRepository.Create(sellerProductMedia);
            _sellerProductMediaRepository.Savechange();
            return operation.Succedded("آپلود موفقیت آمیز بود");
        }

        public List<SellerGalleryViewModel> GetUserGalleryMediasByUserId(long userId)
        {
            return _sellerProductMediaRepository.GetUserGalleryMediasByUserId(userId);
        }
    }
}
