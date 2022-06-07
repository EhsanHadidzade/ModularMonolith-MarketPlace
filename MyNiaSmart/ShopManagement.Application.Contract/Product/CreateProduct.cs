using _0_Framework.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage =ValidationMessage.IsRequired)]
        public string Title { get; set; }
        public string Description { get; set; }

        //[FileExtentionLimitation(new string[] {".png"},ErrorMessage =ValidationMessage.InvalidFileFormat)]
        public IFormFile Picture { get; set; }
        public string PictureUrl { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PartNumber { get;  set; }
        public int ProductWeight { get;  set; }
        public string Dimensions { get;  set; }
        public string CountryMadeIn { get;  set; }
        public string Slug { get; set; }

        //selectedCategories
        [Range(1,long.MaxValue,ErrorMessage =ValidationMessage.IsRequired)]
        public long ProductBrandId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductModelId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductStatusId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductTypeId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductUsageTypeId { get; set; }

    }

    
}
