using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClientHystrix.Services
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

        public async Task<List<string>> GetValuesAsync()
        {
            var result = await _httpClient.GetStringAsync("api/values");
            return new List<string> { result };
        }
    }
}
