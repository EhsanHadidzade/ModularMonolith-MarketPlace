using _0_Framework.Infrastructure;
using _0_Framework.Utilities;
using Microsoft.EntityFrameworkCore;
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
            //To Get All default product of admin
            var mainShopProducts = _context.Products.Select(x => new MainShopProductViewModel
            {
                Id = x.Id,
                FarsiTitle = x.FarsiTitle,
                EngTitle = x.EngTitle,
                Picture = x.Picture,
                Description = x.Descriotion.Substring(0, 300),
                PartNumber = x.PartNumber,
                Slug = x.Slug
            }).ToList();
            var mainShopProductsIds = mainShopProducts.Select(x => x.Id).ToList();

            //to Get all sellerProducts 
            var SellerProducts = _context.SellerProducts.Select(x => new {
                x.ProductId,
                x.Price,
                x.WarrantyTypeId, 
                x.WarrantyAmount, 
                x.isConfirmedByAdmin 
            }
            ).Where(x => x.isConfirmedByAdmin).ToList();
            var productIdsWhichAreSelling = SellerProducts.Select(x => x.ProductId).ToList();

            foreach (var product in mainShopProducts)
            {
                //To Check Current Product Is selling or not
                if (productIdsWhichAreSelling.Any(x => x == product.Id))
                {
                    var MinPrice = SellerProducts.Where(x => x.ProductId == product.Id).Select(x => x.Price).ToList().Min();
                    var MaxValueWarrantyTypeId = SellerProducts.Where(x => x.ProductId == product.Id).Select(x => x.WarrantyTypeId).ToList().Max();
                    var maxValueWarrantyAmount = SellerProducts.Where(x => x.ProductId == product.Id && x.WarrantyTypeId == MaxValueWarrantyTypeId).Select(x => x.WarrantyAmount).ToList().Max();
                    var sellersCount = SellerProducts.Where(x => x.ProductId == product.Id).ToList().Count();
                    product.MinValuePrice = MinPrice.ToMoney();
                    product.SellersCount = sellersCount;
                    product.MaxValueWarrantyTypeId = MaxValueWarrantyTypeId;
                    product.MaxValueWarrantyAmount = maxValueWarrantyAmount;
                    product.IsSellingBetweenSellers = true;
                }
                else
                {
                    product.IsSellingBetweenSellers = false;
                }
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
                EngTitle = x.EngTitle,
            }).FirstOrDefault(x => x.Id == id);
            return product;
        }

        public EditProduct GetDetailsBySlug(string slug)
        {
            return _context.Products.Include(x => x.ProductBrand)
                .Include(x => x.ProductModel)
                .Include(x => x.ProductStatus)
                .Include(x => x.ProductType)
                .Include(x => x.ProductUsageType)
                .Select(x => new EditProduct
                {
                    Id = x.Id,
                    ProductBrandTitle = x.ProductBrand.FarsiTitle,
                    ProductModelTitle = x.ProductModel.FarsiTitle,
                    ProductStatusTitle = x.ProductStatus.FarsiTitle,
                    ProductTypeTitle = x.ProductType.FarsiTitle,
                    ProductUsageTypeTitle = x.ProductUsageType.FarsiTitle,
                    FarsiTitle = x.FarsiTitle,
                    EngTitle = x.EngTitle,
                    Description = x.Descriotion,
                    PartNumber = x.PartNumber,
                    CountryMadeIn = x.CountryMadeIn,
                    Dimensions = x.Dimensions,
                    ProductWeight = x.ProductWeight,
                    Slug = x.Slug,
                    PictureUrl = x.Picture
                }).FirstOrDefault(x => x.Slug == slug);
        }

        public long GetIdBySlug(string slug)
        {
            var product = _context.Products.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Slug == slug);
            return product.Id;
        }
    }
}
