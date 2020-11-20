using Store.Common.Data.Entities;
using System.Collections.Generic;

namespace Store.Backend.Models
{
    public class ShopViewModel
    {
        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public List<Brand> Brands { get; set; }
    }
}
