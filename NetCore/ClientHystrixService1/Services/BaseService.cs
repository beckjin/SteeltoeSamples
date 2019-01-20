using System.Net.Http;
using System.Threading.Tasks;

namespace ClientHystrixService1.Services
{
    public class BaseService : IBaseService
    {
        private readonly HttpClient _httpClient;

        public BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetValueAsync()
        {
            var result = await _httpClient.GetStringAsync("api/values");
            return result;
        }
    }
}
