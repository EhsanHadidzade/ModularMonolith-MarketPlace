﻿using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.ProductCategory.ProductType;
using ShopManagement.Domain.ProductCategoryAgg.ProductTypeAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductTypeRepository : BaseRepository<long, ProductType>, IProductTypeRepository
    {
        private readonly ShopContext _context;

        public ProductTypeRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductType GetDetails(long id)
        {
            return _context.ProductTypes.Select(x => new EditProductType
            {
                Id = x.Id,
                EngTitle = x.EngTitle,
                FarsiTitle = x.FarsiTitle,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductTypeViewModel> GetList()
        {
            return _context.ProductTypes.Select(x => new ProductTypeViewModel
            {
                Id = x.Id,
                EngTitle = x.EngTitle,
                FarsiTitle=x.FarsiTitle
            }).ToList();
        }
    }
}
