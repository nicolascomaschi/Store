using Store.Common.Data;
using Store.Common.Data.Entities;
using Store.Common.Resources;
using Store.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Repositories.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly DataContext context;

        public BrandRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetComboBrand()
        {
            var list = this.context.Brands.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = Strings.ComboBrand,
                Value = "0"
            });

            return list;

        }
    }
}