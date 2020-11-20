using Store.Common.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Backend.Models
{
    public class AddItemViewModel
    {
        [Display(ResourceType = typeof(Strings), Name = "Product")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorDDL")]
        public int ProductId { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "Quantity")]
        [Range(1, double.MaxValue, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorIntMin")]
        public double Quantity { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }
    }
}
