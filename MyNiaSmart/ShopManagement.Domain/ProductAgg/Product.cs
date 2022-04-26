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
    public class Product:BaseEntity<int>
    {
        #region Properties
        public double UnitPrice { get; private set; }
        public int ProductWeight { get; private set; }
        public string Dimensions { get; private set; }
        public string CountryMadeIn { get; private set; }

        //Fk
        public int ProductBrandId { get; set; }
        public int ProductModelId { get; set; }
        public int ProductStatusId { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductUsageTypeId { get; set; }
        #endregion

        #region Relations
        public ProductBrand ProductBrand { get; set; }
        public ProductModel ProductModel { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductType ProductType { get; set; }
        public ProductUsageType ProductUsageType { get; set; }

        public Product(double unitPrice, int productWeight, string dimensions,
            string countryMadeIn, int productBrandId, int productModelId,
            int productStatusId, int productTypeId, int productUsageTypeId)
        {
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
        #endregion




    }
}
