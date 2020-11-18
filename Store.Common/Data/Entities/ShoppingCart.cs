using Store.Common.Data.Interfaces;
using Store.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Store.Common.Data.Entities
{
	public class ShoppingCart : IEntity
	{
		public int Id { get; set; }

		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public User User { get; set; }

		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public Product Product { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Price")]
		[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
		public decimal Price { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Discount")]
		[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
		public decimal Discount { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Quantity")]
		[DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
		public double Quantity { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Value")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal Value => (this.Price - this.Discount) * (decimal)this.Quantity;

	}
}
