using Store.Common.Data.Interfaces;
using Store.Common.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Common.Data.Entities
{
	public class Product : IEntity
	{
		public int Id { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Product")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public string Name { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Image")]
		public string ImageUrl { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Price")]
		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
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

		[Display(ResourceType = typeof(Strings), Name = "DateModification")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
		public DateTime DateModification { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "DateModification")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
		public DateTime? DateModificationLocal
		{
			get
			{
				if (this.DateModification == null)
				{
					return null;
				}

				return this.DateModification.ToLocalTime();
			}
		}

		[Display(ResourceType = typeof(Strings), Name = "DateCration")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
		public DateTime DateCration { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "DateCration")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
		public DateTime? DateCrationLocal
		{
			get
			{
				if (this.DateCration == null)
				{
					return null;
				}

				return this.DateCration.ToLocalTime();
			}
		}

		[Display(ResourceType = typeof(Strings), Name = "IsAvailabe")]
		public bool IsAvailabe { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Description")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		public string Description { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Size")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		public string Size { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Remark")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		public string Remark { get; set; }

		public string ImageFullPath
		{
			get
			{
				if (string.IsNullOrEmpty(this.ImageUrl))
				{
					return null;
				}

				return $"{Strings.UrlAzure}{this.ImageUrl.Substring(1)}";
			}
		}

		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public Category Category { get; set; }

		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public Subcategory Subcategory { get; set; }

		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public Brand Brand { get; set; }

		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public Presentation Presentation { get; set; }

		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public User User { get; set; }
	}
}
