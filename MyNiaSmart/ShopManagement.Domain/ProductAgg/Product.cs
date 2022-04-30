using _0_Framework.Domain;
using ShopManagement.Domain.ProductBrandAgg;
using ShopManagement.Domain.ProductModelAgg;
using ShopManagement.Domain.ProductStatusAgg;
using ShopManagement.Domain.ProductTypeAgg;
using ShopManagement.Domain.ProductUsageTypeAgg;
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
        public string Title { get; private set; }
        public string Descriotion { get; private set; }
        public string Picture { get; private set; }
        public double UnitPrice { get; private set; }
        public int ProductWeight { get; private set; }
        public string Dimensions { get; private set; }
        public string CountryMadeIn { get; private set; }

        //Fk
        public long ProductBrandId { get; set; }
        public long ProductModelId { get; set; }
        public long ProductStatusId { get; set; }
        public long ProductTypeId { get; set; }
        public long ProductUsageTypeId { get; set; }
        #endregion

        #region Relations
        public ProductBrand ProductBrand { get; set; }
        public ProductModel ProductModel { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductType ProductType { get; set; }
        public ProductUsageType ProductUsageType { get; set; }
        #endregion



        public Product(string title, string descriotion, string picture,
            double unitPrice, int productWeight, string dimensions,
            string countryMadeIn, long productBrandId, long productModelId,
            long productStatusId, long productTypeId, long productUsageTypeId)
        {
            Title = title;
            Descriotion = descriotion;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            UnitPrice = unitPrice;
            ProductWeight = productWeight;
            Dimensions = dimensions;
            CountryMadeIn = countryMadeIn;
            ProductBrandId = productBrandId;
            ProductModelId = productModelId;
            ProductStatusId = productStatusId;
            ProductTypeId = productTypeId;
            ProductUsageTypeId = productUsageTypeId;
        }


        public void Edit(string title, string descriotion, string picture,
           double unitPrice, int productWeight, string dimensions,
           string countryMadeIn, long productBrandId, long productModelId,
           long productStatusId, long productTypeId, long productUsageTypeId)
        {
            Title = title;
            Descriotion = descriotion;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            UnitPrice = unitPrice;
            ProductWeight = productWeight;
            Dimensions = dimensions;
            CountryMadeIn = countryMadeIn;
            ProductBrandId = productBrandId;
            ProductModelId = productModelId;
            ProductStatusId = productStatusId;
            ProductTypeId = productTypeId;
            ProductUsageTypeId = productUsageTypeId;
        }





    }
}
