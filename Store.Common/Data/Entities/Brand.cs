using Store.Common.Data.Interfaces;
using Store.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Store.Common.Data.Entities
{
	public class Brand : IEntity
	{
		public int Id { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Brand")]
		[MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public string Name { get; set; }

		public User User { get; set; }
	}
}
