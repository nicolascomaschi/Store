using Store.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Store.Backend.Models
{
	public class ShopProductViewModel
	{
		public int Id { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Product")]
		public string Name { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Image")]
		public string ImageUrl { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Price")]
		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		public double Price { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Discount")]
		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		public double Discount { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "EspecialPrice")]
		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		public double EspecialPrice { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "EspecialQuantity")]
		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		public double EspecialQuantity { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Quantity")]
		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		public double Quantity { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Size")]
		public string Size { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Description")]
		public string Description { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Remark")]
		public string Remark { get; set; }

	}
}
