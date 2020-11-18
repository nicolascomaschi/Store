using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Store.Backend.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);
    }

}
