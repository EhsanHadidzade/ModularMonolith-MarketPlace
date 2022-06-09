using _0_Framework.Utilities;
using ShopManagement.Application.Contract.SellerProduct;
using ShopManagement.Domain.SellerPanelAgg;
using ShopManagement.Domain.SellerProductAgg;
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
        private readonly ISelleProductRepository _selleProductRepository;
        private readonly OperationResult operation;

        public SellerProductApplication(ISellerPanelRepository sellerPanelRepository,
            ISelleProductRepository selleProductRepository)
        {
            _sellerPanelRepository = sellerPanelRepository;
            _selleProductRepository = selleProductRepository;
            operation = new OperationResult();
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
            return operation.Succedded("محصول با موفقیت اضافه و در حال بررسی توصط ادمین میباشد. در صورت تایید به فروشگاه اضافه خواهد شد");

        }

        public OperationResult Edit(EditSellerProduct command)
        {
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
    }
}
