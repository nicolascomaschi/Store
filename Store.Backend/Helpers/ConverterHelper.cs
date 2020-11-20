//using Store.Backend.Models;
using Store.Common.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Store.Backend.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        //public Product ToProduct(ProductCreateViewModel view, string path, Category category, Subcategory subcategory,
        //    Brand brand, Presentation presentation, User user)
        //{
        //    return new Product
        //    {
        //        ImageUrl = path,
        //        IsAvailabe = true,
        //        Name = view.Name,
        //        Description = view.Description,
        //        Size = view.Size,
        //        DateCration = DateTime.UtcNow,
        //        DateModification = DateTime.UtcNow,
        //        Price = view.Price,
        //        Discount = view.Discount,
        //        EspecialPrice = view.EspecialPrice,
        //        EspecialQuantity = view.EspecialQuantity,
        //        Category = category,
        //        Subcategory = subcategory,
        //        Presentation = presentation,
        //        Brand = brand,
        //        User = user,
        //        Remark = view.Remark,
        //    };
        //}

        //public ProductCreateViewModel ToProductViewModel(Product product)
        //{
        //    return new ProductCreateViewModel
        //    {
        //        Price = product.Price,
        //        Discount = product.Discount,
        //        EspecialPrice = product.EspecialPrice,
        //        EspecialQuantity = product.EspecialQuantity,
        //        Name = product.Name,
        //        Description = product.Description,
        //        Size = product.Size,
        //        Id = product.Id,
        //        ImageUrl = product.ImageUrl,
        //        IsAvailabe = product.IsAvailabe,
        //        DateCration = product.DateCration,
        //        Remark = product.Remark,
        //    };
        //}
    }
}
