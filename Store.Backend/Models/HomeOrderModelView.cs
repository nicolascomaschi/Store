using Store.Common.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Store.Backend.Models
{
    public class HomeOrderModelView
    {
        public IEnumerable<Order> Orders { get; set; }

        public int TotalProduct => this.Orders == null ? 0 : this.Orders.Sum(i => i.Lines);

        public int TotalOrderShipment => this.Orders == null ? 0 : this.Orders.Count(o => o.Status == "Despachado");

        public int TotalOrderPending => this.Orders == null ? 0 : this.Orders.Count(o => o.Status != "Despachado");

        public IEnumerable<User> Users { get; set; }

        public int TotalUsers => this.Users == null ? 0 : this.Users.Count();
    }
}
