using Microsoft.AspNetCore.Http;
using Store.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Backend.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        public int SubcategoryId { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "Subcategory")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "Image")]
        public IFormFile ImageFile { get; set; }

        public string ImageUrl { get; set; }
    }
}
