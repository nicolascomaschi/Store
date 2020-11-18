using Store.Common.Data.Interfaces;
using Store.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Store.Common.Data.Entities
{
	public class Order : IEntity
	{
		public int Id { get; set; }

		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		[Display(ResourceType = typeof(Strings), Name = "OrderDate")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}", ApplyFormatInEditMode = false)]
		public DateTime OrderDate { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "OrderDate")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
		public DateTime? OrderDateLocal
		{
			get
			{
				if (this.OrderDate == null)
				{
					return null;
				}

				return this.OrderDate.ToLocalTime();
			}
		}

		[Display(ResourceType = typeof(Strings), Name = "Status")]
		[Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
		public string Status { get; set; }

		[Required]
		public User User { get; set; }

		public IEnumerable<OrderDetail> Items { get; set; }

		[Display(ResourceType = typeof(Strings), Name = "Quantity")]
		[DisplayFormat(DataFormatString = "{0:N2}")]
		public double Quantity => this.Items == null ? 0 : this.Items.Sum(i => i.Quantity);

		[Display(ResourceType = typeof(Strings), Name = "Value")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		public decimal Value => this.Items == null ? 0 : this.Items.Sum(i => i.Value);

		[Display(ResourceType = typeof(Strings), Name = "Lines")]
		[DisplayFormat(DataFormatString = "{0:N0}")]
		public int Lines => this.Items == null ? 0 : this.Items.Count();

	}
}
