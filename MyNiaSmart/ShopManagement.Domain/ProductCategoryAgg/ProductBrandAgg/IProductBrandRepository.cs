﻿using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductCategory.ProductBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg.ProductBrandAgg
{
    public interface IProductBrandRepository : IRepository<long, ProductBrand>
    {
        EditProductBrand GetDetails(long id);
        List<ProductBrandViewModel> GetList();
    }
}
