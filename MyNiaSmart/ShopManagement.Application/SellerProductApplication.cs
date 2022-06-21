using _0_Framework.Contract;
using _0_Framework.Utilities;
using ShopManagement.Application.Contract.SellerProduct;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.SellerPanelAgg;
using ShopManagement.Domain.SellerProductAgg;
using ShopManagement.Domain.SellerProductMediaAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SellerProductApplication : ISellerProductApplication
    {
        private readonly ISellerPanelRepository _sellerPanelRepository;
        private readonly ISellerProductRepository _selleProductRepository;
        private readonly ISellerProductMediaRepository _sellerProductMediaRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAuthHelper _authHelper;
        private readonly OperationResult operation;

        public SellerProductApplication(ISellerPanelRepository sellerPanelRepository,
            ISellerProductRepository selleProductRepository, ISellerProductMediaRepository sellerProductMediaRepository,
            IAuthHelper authHelper, IProductRepository productRepository)
        {
            _sellerPanelRepository = sellerPanelRepository;
            _selleProductRepository = selleProductRepository;
            operation = new OperationResult();
            _sellerProductMediaRepository = sellerProductMediaRepository;
            _authHelper = authHelper;
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateSellerProduct command)
        {
            if (_selleProductRepository.IsExist(x => x.SellerPanelId == command.SellerPanelId && x.ProductId == command.ProductId))
                return operation.Failed($" محصول ({command.ProductTitle}) قبلا به فروشگاه شما اضافه شده و امکان افزودن مجدد آن وجود ندارد");

            var product = new SellerProduct(command.SellerPanelId, command.ProductId, command.Price,
                command.Description, command.MarketerSharePercent, command.MarketerShareAmount,
                command.DeliveryDurationForCity, command.DeliveryDurationForCapital,
                command.DeliveryDurationForOther, command.CanMarketerSee, command.BuyersCategory,
                command.WarrantyTypeId, command.WarrantyAmount);
            _selleProductRepository.Create(product);
            _selleProductRepository.Savechange();
            #region AddMediaFromSellerGallery
            if(command.SelectedMediaIds.Count>0)
            _sellerProductMediaRepository.SelectMediaByMediaIds(command.SelectedMediaIds,product.Id);
            #endregion
            return operation.Succedded("محصول با موفقیت اضافه و در حال بررسی توصط ادمین میباشد. در صورت تایید به فروشگاه اضافه خواهد شد");
        }

        public OperationResult Edit(EditSellerProduct command)
        {
            var userId = _authHelper.CurrentAccountInfo().Id;
            var product = _selleProductRepository.GetById(command.Id);
            if(product == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_selleProductRepository.IsExist(x => x.SellerPanelId == command.SellerPanelId && x.ProductId == command.ProductId && x.Id!=command.Id))
                return operation.Failed($" محصول ({command.ProductTitle}) قبلا به فروشگاه شما اضافه شده و امکان افزودن مجدد آن وجود ندارد");

            product.Edit(command.ProductId, command.Price,
                command.Description, command.MarketerSharePercent, command.MarketerShareAmount,
                command.DeliveryDurationForCity, command.DeliveryDurationForCapital,
                command.DeliveryDurationForOther, command.CanMarketerSee, command.BuyersCategory,
                command.WarrantyTypeId, command.WarrantyAmount);
            _selleProductRepository.Savechange();
            #region EditMediasOf Seller Product
            //First we un select former Medias , then Select New Ones
            _sellerProductMediaRepository.UnSelectMediasByMediaIds(userId,product.Id);
            _sellerProductMediaRepository.SelectMediaByMediaIds(command.SelectedMediaIds, product.Id);
            #endregion
            return operation.Succedded();
        }

        public EditSellerProduct GetDetails(long id)
        {
            return _selleProductRepository.GetDetails(id);
        }

        public List<SellerProductViewModel> GetList()
        {
            return _selleProductRepository.GetList();
        }
        public CreateSellerProduct PrepareModelForCreationBySellerPanelId(long sellerPanelId)
        {
            var sellerPanel = _sellerPanelRepository.GetById(sellerPanelId);
            var command = new CreateSellerProduct
            {
                SellerPanelId = sellerPanelId,
                BuyersCategory = sellerPanel.BuyersCategory,
                DeliveryDurationForCity = sellerPanel.DeliveryDurationForCity,
                DeliveryDurationForCapital = sellerPanel.DeliveryDurationForCapital,
                DeliveryDurationForOther = sellerPanel.DeliveryDurationForOther,
                WarrantyAmount = sellerPanel.WarrantyAmount,
                WarrantyTypeId = sellerPanel.WarrantyTypeId,
            };
            return command;
        }

        public OperationResult ConfirmAProductByAdmin(long sellerProductId)
        {
            var product = _selleProductRepository.GetById(sellerProductId);
            product.ConfirmByAdmin();
            _selleProductRepository.Savechange();
            return operation.Succedded("محصول با موفقیت به فروشگاه اصلی افزوده شد");
        }

        public List<SellerProductViewModel> GetListBySellerPanelId(long sellerpanelId)
        {
            return _selleProductRepository.GetListBySellerPanelId(sellerpanelId);

        }

        public SellerProductDetailsToShowViewModel GetDetailsBySellerPanelNameAndProductSlug(string shopName, string productSlug)
        {
            //Default Details Of Product CreatedByAdministrator
            var AdminproductDetails = _productRepository.GetDetailsBySlug(productSlug);


            var sellerPanelId=_sellerPanelRepository.GetIdByName(shopName);
            var productId = _productRepository.GetIdBySlug(productSlug);


            var sellerProductDetails = _selleProductRepository.GetDetailsBySellerPanelIdAndProductId(sellerPanelId,productId);


            var SpecificProductInfo = new SellerProductDetailsToShowViewModel()
            {
                Id = sellerProductDetails.Id,
                //Default Details Of Product CreatedByAdministrator
                FarsiTitle = AdminproductDetails.FarsiTitle,
                CountryMadeIn = AdminproductDetails.CountryMadeIn,
                EngTitle = AdminproductDetails.EngTitle,
                Dimensions = AdminproductDetails.Dimensions,
                PartNumber = AdminproductDetails.PartNumber,
                ProductBrandTitle = AdminproductDetails.ProductBrandTitle,
                ProductModelTitle = AdminproductDetails.ProductModelTitle,
                ProductStatusTitle = AdminproductDetails.ProductStatusTitle,
                ProductTypeTitle = AdminproductDetails.ProductTypeTitle,
                ProductUsageTypeTitle = AdminproductDetails.ProductUsageTypeTitle,
                ProductWeight = AdminproductDetails.ProductWeight,

                //Specific Seller Details Of Product Created ByThem in seller Panel
                BuyersCategory = sellerProductDetails.BuyersCategory,
                CanMarketerSee = sellerProductDetails.CanMarketerSee,
                Description = sellerProductDetails.Description,
                Price = sellerProductDetails.Price,
                DeliveryDurationForCapital = sellerProductDetails.DeliveryDurationForCapital,
                DeliveryDurationForCity = sellerProductDetails.DeliveryDurationForCity,
                DeliveryDurationForOther = sellerProductDetails.DeliveryDurationForOther,
                MarketerShareAmount = sellerProductDetails.MarketerShareAmount,
                MarketerSharePercent = sellerProductDetails.MarketerSharePercent,
                WarrantyAmount = sellerProductDetails.WarrantyAmount,
                WarrantyTypeId = sellerProductDetails.WarrantyTypeId,
                SelectedMedias = sellerProductDetails.SelectedMedias,
            };
            return SpecificProductInfo;
        }
    }
}
