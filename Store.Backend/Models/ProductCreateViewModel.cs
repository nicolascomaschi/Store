using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Backend.Models
{
	public class ProductCreateViewModel
	{
		public int Id { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Product")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public string Name { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Image")]
		public string ImageUrl { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "DateCration")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
		public DateTime DateCration { get; set; }

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

		[Display(ResourceType = typeof(Strings), Name = "Size")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		public string Size { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Description")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		public string Description { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Remark")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		public string Remark { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "IsAvailabe")]
		public bool IsAvailabe { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Image")]
		public IFormFile ImageFile { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Category")]
		[Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorDDL")]
		public int CategoryId { get; set; }

		public IEnumerable<SelectListItem> Categories { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Subcategory")]
		[Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorDDL")]
		public int SubcategoryId { get; set; }

		public IEnumerable<SelectListItem> Subcategories { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Brand")]
		[Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorDDL")]
		public int BrandId { get; set; }

		public IEnumerable<SelectListItem> Brands { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Presentation")]
		[Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorDDL")]
		public int PresentationId { get; set; }

		public IEnumerable<SelectListItem> Presentations { get; set; }
	}
}
