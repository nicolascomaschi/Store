using Store.Common.Data.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Repositories.Interfaces
{
    public interface IPresentationRepository : IGenericRepository<Presentation>
    {
        IEnumerable<SelectListItem> GetComboPresentation();
    }
}
