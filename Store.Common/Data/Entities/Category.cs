using Store.Common.Data.Interfaces;
using Store.Common.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Common.Data.Entities
{
	public class Category : IEntity
	{
		public int Id { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Category")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public string Name { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Image")]
		public string ImageUrl { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Subcategory")]
		public int NumberSubcategories { get { return this.Subcategories == null ? 0 : this.Subcategories.Count; } }

		public ICollection<Subcategory> Subcategories { get; set; }

		public User User { get; set; }

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

	}
}
