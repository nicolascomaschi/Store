using Store.Common.Data.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Store.Repositories.Interfaces
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        IEnumerable<SelectListItem> GetComboBrand();
    }
}
