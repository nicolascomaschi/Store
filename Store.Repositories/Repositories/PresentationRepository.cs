using Store.Common.Data;
using Store.Common.Data.Entities;
using Store.Common.Resources;
using Store.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Repositories.Repositories
{
    public class PresentationRepository : GenericRepository<Presentation>, IPresentationRepository
    {
        private readonly DataContext context;

        public PresentationRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetComboPresentation()
        {
            var list = this.context.Presentations.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = Strings.ComboPresentation,
                Value = "0"
            });

            return list;

        }
    }
}
