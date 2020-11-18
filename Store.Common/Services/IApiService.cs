using Store.Common.Helpers;
using System.Threading.Tasks;

namespace Store.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }
}
