using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductModelAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductStatusAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductTypeAgg;
using ShopManagement.Domain.ProductCategoryAgg.ProductUsageTypeAgg;
using ShopManagement.Domain.SellerProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : BaseEntity
    {
        #region Properties
        public string FarsiTitle { get; private set; }
        public string EngTitle { get; private set; }
        public string Descriotion { get; private set; }
        public string Picture { get; private set; }
        public string PartNumber { get; private set; }
        public int ProductWeight { get; private set; }
        public string Dimensions { get; private set; }
        public string CountryMadeIn { get; private set; }
        public string Slug { get; private set; }

        //Fk
        public long ProductBrandId { get; private set; }
        public long ProductModelId { get; private set; }
        public long ProductTypeId { get; private set; }
        public long ProductUsageTypeId { get; private set; }
        public long ProductStatusId { get; private set; }
        #endregion

        #region Relations
        public ProductBrand ProductBrand { get; set; }
        public ProductModel ProductModel { get; set; }
        public ProductType ProductType { get; set; }
        public ProductUsageType ProductUsageType { get; set; }
        public List<SellerProduct> SellerProducts{ get; private set; }
        public ProductStatus ProductStatus { get; set; }
        #endregion



        public Product(string farsiTitle, string engTitle, string descriotion, string picture,
            string partNumber, int productWeight, string dimensions,
            string countryMadeIn,string slug, long productBrandId, long productModelId,
            long productStatusId, long productTypeId, long productUsageTypeId)
        {
            FarsiTitle = farsiTitle;
            EngTitle = engTitle;
            Descriotion = descriotion;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PartNumber = partNumber;
            ProductWeight = productWeight;
            Dimensions = dimensions;
            CountryMadeIn = countryMadeIn;
            Slug= slug;

            //FK
            ProductBrandId = productBrandId;
            ProductModelId = productModelId;
            ProductStatusId = productStatusId;
            ProductTypeId = productTypeId;
            ProductUsageTypeId = productUsageTypeId;

            SellerProducts = new List<SellerProduct>();
        }


        public void Edit(string farsiTitle,string engTitle, string descriotion, string picture,
           string partNumber, int productWeight, string dimensions,
           string countryMadeIn,string slug, long productBrandId, long productModelId,
           long productStatusId, long productTypeId, long productUsageTypeId)
        {
            FarsiTitle = farsiTitle;
            EngTitle= engTitle;
            Descriotion = descriotion;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PartNumber = partNumber;
            ProductWeight = productWeight;
            Dimensions = dimensions;
            CountryMadeIn = countryMadeIn;
            Slug=slug;

            //FK
            ProductBrandId = productBrandId;
            ProductModelId = productModelId;
            ProductStatusId = productStatusId;
            ProductTypeId = productTypeId;
            ProductUsageTypeId = productUsageTypeId;
        }


    }
}
