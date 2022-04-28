using ShopManagement.Application.Contract.ProductModel;

namespace ShopManagement.Application.Contract.ProductModel
{
    public class EditProductModel:CreateProductModel
    {
        public long Id { get; set; }
    }
}
