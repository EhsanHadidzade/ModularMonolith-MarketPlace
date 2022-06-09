using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : BaseRepository<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<MainShopProductViewModel> GetListForMainShop()
        {
            var mainShopProducts = _context.Products.Select(x => new MainShopProductViewModel
            {
                Id = x.Id,
                FarsiTitle = x.FarsiTitle,
                EngTitle = x.EngTitle,
                Picture = x.Picture,
                Description = x.Descriotion.Substring(0,300),
                PartNumber = x.PartNumber,
                Slug = x.Slug,
            }).ToList();

            var query = _context.SellerProducts.Select(x => new { x.ProductId, x.Price, x.WarrantyTypeId, x.WarrantyAmount, x.isConfirmedByAdmin }).Where(x => x.isConfirmedByAdmin);
            if (query.Count()==0)
            {
                foreach (var product in mainShopProducts)
                {
                    product.IsSellingBetweenSellers = false;
                }
                return mainShopProducts;
            }

            foreach (var product in mainShopProducts)
            {
                var MinPrice = query.Where(x => x.ProductId == product.Id).Select(x => x.Price).Min();
                var MaxValueWarrantyTypeId = query.Where(x => x.ProductId == product.Id).Select(x => x.WarrantyTypeId).Max();
                var maxValueWarrantyAmount = query.Where(x => x.ProductId == product.Id && x.WarrantyTypeId == MaxValueWarrantyTypeId).Select(x => x.WarrantyAmount).Max();
                bool IsSellingBySellers = query.Any(x => x.ProductId == product.Id);
                product.MinValuePrice = MinPrice.ToMoney();
                product.MaxValueWarrantyTypeId = MaxValueWarrantyTypeId;
                product.MaxValueWarrantyAmount = maxValueWarrantyAmount;
                product.IsSellingBetweenSellers = IsSellingBySellers;
            }
            return mainShopProducts;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                ProductBrandId = x.ProductBrandId,
                ProductModelId = x.ProductModelId,
                ProductStatusId = x.ProductStatusId,
                ProductTypeId = x.ProductTypeId,
                ProductUsageTypeId = x.ProductUsageTypeId,
                FarsiTitle = x.FarsiTitle,
                EngTitle = x.EngTitle,
                Description = x.Descriotion,
                PartNumber = x.PartNumber,
                CountryMadeIn = x.CountryMadeIn,
                Dimensions = x.Dimensions,
                ProductWeight = x.ProductWeight,
                Slug = x.Slug,
                PictureUrl = x.Picture
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductViewModel> GetList()
        {
            return _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Picture = x.Picture,
                EngTitle = x.EngTitle,
                PartNumber = x.PartNumber,
                CreationDate = x.CreationDate.ToFarsi(),
                Slug = x.Slug,
            }).ToList();
        }

        public ProductViewModel GetTitleAndIdById(long id)
        {
            var product = _context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                FarsiTitle = x.FarsiTitle,
                EngTitle=x.EngTitle,
            }).FirstOrDefault(x => x.Id == id);
            return product;
        }
    }
}
