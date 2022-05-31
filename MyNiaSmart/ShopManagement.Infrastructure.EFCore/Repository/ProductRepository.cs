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

        public ProductRepository(ShopContext context):base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
           return _context.Products.Select(x=>new EditProduct 
           {
               Id=x.Id,
               ProductBrandId=x.ProductBrandId,
               ProductModelId=x.ProductModelId,
               ProductStatusId=x.ProductStatusId,
               ProductTypeId=x.ProductTypeId,
               ProductUsageTypeId=x.ProductUsageTypeId,
               Title=x.Title,
               Description=x.Descriotion,
               PartNumber=x.PartNumber,
               CountryMadeIn=x.CountryMadeIn,
               Dimensions=x.Dimensions,
               ProductWeight=x.ProductWeight
           }).FirstOrDefault(x=>x.Id == id);   
        }

        public List<ProductViewModel> GetList()
        {
            return _context.Products.Select(x=>new ProductViewModel
            {
                Id = x.Id,
                Picture=x.Picture,
                Title=x.Title,
                PartNumber=x.PartNumber,
                CreationDate=x.CreationDate.ToFarsi()
            }).ToList();
        }
    }
}
