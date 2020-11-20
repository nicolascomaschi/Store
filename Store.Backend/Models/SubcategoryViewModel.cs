using Store.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Store.Backend.Models
{
	public class SubcategoryViewModel
	{
		public int CategoryId { get; set; }

		public int SubcategoryId { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Subcategory")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public string Name { get; set; }
	}
}
